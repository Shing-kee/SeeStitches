using System.Collections;
using System.Collections.Generic;
using UnityEngine;

///<Summary>
///Object pool
///</Summary>
public class PinPool : MonoBehaviour
{
    private static PinPool _instance;
    public static PinPool Instance{
        get{
            return _instance;
        }
    }

    public List<GameObject> pins = new List<GameObject>();
    private List<GameObject> lists = new List<GameObject>();

    public static int Max = 10;    

    private void Start(){
        _instance = this;
    }

    private void CreatePin(){
        GameObject prefab = Resources.Load("Prefabs/Pin") as GameObject;
        if(lists.Count >= Max){
            Debug.Log("pins must be loss number :" + Max);
            return;
        }
        for(int i = 0; i < Max; i++){
            prefab.tag = "Untagged";
            lists.Add(prefab);
        }
    }

    public void LoadPin(Transform parentTrans){
        CreatePin();
        foreach (GameObject list in lists)
        {
            GameObject obj = Instantiate(list);
            obj.transform.position = new Vector3(0,6,0);
            obj.transform.parent = parentTrans;
            obj.gameObject.SetActive(false);
            pins.Add(obj);
        }
    }

    public void ClearPin(){
        lists.Clear();
        pins.Clear();
    }
}
