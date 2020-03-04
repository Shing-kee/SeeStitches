using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    private GameObject enemy;
    private GameObject gamer;
    private Camera mainCamera;
    private static int levelPinsNumber = 10;
    public delegate void OnDelegate();
    public event OnDelegate OnPause;
   
    void Start()
    {
        Init();
        InitOther();
        levelPinsNumber = PinPool.Max;
    }
    private void Update(){
        if(BulletCtrl.isOver){
            StartCoroutine(Reload());
        }
        if(EnemySelf.Score == levelPinsNumber){
            StartCoroutine(Next());
        }
        if(GameCtrl.isPause){
            OnPause.Invoke();
            if(!GameCtrl.isGame){
                ChangeScene();
            }
        }else{
            OnPause.Invoke();
        }
    }

    private void InitOther(){
        enemy = GameObject.Find("EnemyPos");
        gamer = GameObject.Find("PinPos");
        if(enemy == null || gamer == null){
            return;
        }

        mainCamera = Camera.main;
    }
    //Initiate the game when start
    private void Init(){
        if(transform.tag == "GM"){
            if(_instance == null){
                _instance = this;
            }
            else{
                Destroy(_instance);
            }
        }
        else{
            Destroy(this);
        }
    }  
    //return to title
    private void ChangeScene(){
        GameCtrl.isPause = false;
        SceneManager.LoadScene("Begin");
        InitToOver();
    }
    //enabled by gameObject if any program is dead
    private void Enabled(bool state){
        if(state){state=false;}else{state = true;}
        enemy.GetComponent<EnemySelf>().enabled = state;
        gamer.GetComponent<Player>().enabled = state;
    } 
    public void Pausing(bool state){
        Enabled(state);
    }
    //Initiate the game when reload
    private void InitToOver(){
        BulletCtrl.isOver = false;
        PinPool.Instance.ClearPin();
        EnemySelf.Score = 0;
        EnemySelf.vel = 2.0f;
        PinPool.Max = 10;
        levelPinsNumber = PinPool.Max;
    }

    IEnumerator Reload(){
        StartCoroutine(Over());
        while(BulletCtrl.isOver){
            if(!GameCtrl.isPause){
                Enabled(BulletCtrl.isOver);
                mainCamera.backgroundColor = Color.Lerp(mainCamera.backgroundColor,Color.red,2);
                yield return 0;
            }
        }   
    }
    IEnumerator Over(){
        yield return new WaitForSeconds(3.0f);
        InitToOver();
        SceneManager.LoadScene("Main");   
    }
    IEnumerator Next(){
        yield return new WaitForSeconds(3.0f);
        PinPool.Max += 2;
        levelPinsNumber = PinPool.Max;
        PinPool.Instance.ClearPin();
        EnemySelf.Score = 0;
        if(levelPinsNumber >= 14){
            PinPool.Max = 10;
            EnemySelf.vel += 0.5f;
        }
        SceneManager.LoadScene("Main");
    }
}
