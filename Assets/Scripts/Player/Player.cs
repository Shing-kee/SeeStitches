using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Vector2 m_screenPos;
    private static Transform _self;
    public static Transform Self{
        get{
            return _self;
        }
    }

    void Start()
    {
        _self = this.transform;
        PinPool.Instance.LoadPin(transform);
        Self.GetChild(0).gameObject.SetActive(true);
    }

    public void Shot(Transform parentTrans){
        if(!BulletCtrl.isOver){
            if(parentTrans.childCount <= 1){
                parentTrans.GetChild(0).GetComponent<Rigidbody>().velocity += Vector3.up * 12f;
                parentTrans.GetChild(0).tag = "Pin";
            }else{
                for(int i = 0; i < parentTrans.childCount; i++){
                    Vector3 velo = Vector3.zero;
                    if(parentTrans.childCount == 0){
                        return;
                    }
                    velo = parentTrans.GetChild(0).GetComponent<Rigidbody>().velocity;
                    if(velo != Vector3.zero){
                        return;
                    }
                    parentTrans.GetChild(0).GetComponent<Rigidbody>().velocity += Vector3.up * 12f;
                    parentTrans.GetChild(0).tag = "Pin";
                    parentTrans.GetChild(1).gameObject.SetActive(true);
                }
            }
        }   
    }
}
