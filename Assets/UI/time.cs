using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class time : MonoBehaviour {

    //time変数
    public float timecount;
    public Text timelabel;
    public GameObject gameobject;
    int point=100;
	// Use this for initialization
    public void Start () {
        //制限時間
        timecount = 3;

        gameobject.GetComponent<score>().countpoint(point);
        
	}
	
	// Update is called once per frame
	void Update () {
       //time表示
        timelabel.text = string.Format("Time:{0:00}",timecount);
        //time減少
        timecount -= Time.deltaTime;
        //ポイント数
        FindObjectOfType<score>().countpoint(100);
        //time0になった時
        if (timecount <= 0.0f)
        {
            timecount = 0;
            
        }
    }
}
