using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemySelf : MonoBehaviour
{
    private EnemySelf self;
    private Vector3 rot;
    public Text txt; 
    public static int Score = 0;
    public static float vel = 2.0f;

    void Start()
    {
        self = transform.GetComponent<EnemySelf>();
        rot = new Vector3(0,0,vel);
        txt = GameObject.Find("Score").GetComponent<Text>();
        txt.text = Score.ToString();
    }

    void Update()
    {
        self.transform.Rotate(rot,Space.World);
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Pin")
        {
            col.GetComponent<Rigidbody>().velocity = Vector3.zero;
            col.transform.parent = transform;
            if(!BulletCtrl.isOver){
                Score++;
                txt.text = Score.ToString(); 
            }
        }
    }
    
}
