using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class time : MonoBehaviour {

    //time変数
    public float timecount;
    public Text timelabel;
    public GameObject gameobject;

    //大切だから消さないで　タイムを取得する時に使う
    public float GetTime()
    {
        return timecount;
    } 

	// Use this for initialization
    public void Start () {
        //制限時間
        timecount = 60;
        
	}
	
	// Update is called once per frame
	void Update () {
       //time表示
        timelabel.text = string.Format("Time:{0:00}",timecount);
        //time減少
        timecount -= Time.deltaTime;
        //time0になった時
        if (timecount <= 0.0f)
        {
            timecount = 0;

        }
        else
        {
            //ポイント数
            FindObjectOfType<score>().AddScore(1);
        }
    }
}
