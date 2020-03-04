using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameCtrl : MonoBehaviour
{
    public GameManager GM;
    public Button btnPause;
    public Button btnReturn;
    public Button btnCancel;
    public GameObject PauseMenu;
    public static bool isPause;
    public static bool isGame;

    private Player gamer;
    void Start()
    {
        GM.OnPause += DoPause;
        btnPause = GameObject.Find("Pause").GetComponent<Button>();
        PauseMenu = GameObject.Find("PauseMenu");
        btnReturn = GameObject.Find("Return").GetComponent<Button>();
        btnCancel = GameObject.Find("Cancel").GetComponent<Button>();
        gamer = new Player();
        isGame = true;

        btnPause.onClick.AddListener(delegate (){
            isPause = CheckState(isPause);
        });
        btnCancel.onClick.AddListener(delegate(){
            isPause = CheckState(isPause);
        });
        btnReturn.onClick.AddListener(delegate(){
            isGame = CheckState(isGame);
            PauseMenu.SetActive(false);
        });
    }

    void Update()
    {
        
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if(Physics.Raycast(ray,out hit)){
                gamer.Shot(Player.Self);
            }
    }

    void DoPause(){
        if(btnPause == null){return;}
        PauseMenu.SetActive(isPause);
        GM.Pausing(isPause);
    }

    //check to change what the game state
    private bool CheckState(bool state){
        // Debug.Log(state);
        if(!state){
            state = true;
            return state;
        }
        state = false;
        return state;
    }
}
