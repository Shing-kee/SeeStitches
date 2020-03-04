using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCtrl : MonoBehaviour
{
    public static bool isOver = false;
   void OnTriggerEnter(Collider col){
       if(col.tag == transform.gameObject.tag){
           Debug.Log(col.tag);
           isOver = true;
       }
   }
}
