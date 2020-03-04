using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

///<summary>
///Begin_scene program
///</summary>
public class StartMgr : MonoBehaviour
{
    private Button btnStart;
    private Text txtMaxScore;
    void Start()
    {
        btnStart = GameObject.Find("Start").GetComponent<Button>();
        btnStart.onClick.AddListener(delegate (){
            StartCoroutine(LoadScene());
        });
    }

    IEnumerator LoadScene(){
        yield return 0;
        SceneManager.LoadScene("Main");
    }
}
