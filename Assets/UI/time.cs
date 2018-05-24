using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class time : MonoBehaviour {

    //time変数
    public float timecount;
    public Text timelabel;

    //タイムのゲットメソッド
    public float GetTime()
    {
        return timecount;
    }
    
	// Use this for initialization
    void Start () {
        //制限時間
        timecount = 60;
	}
	
	// Update is called once per frame
	void Update () {
       //time表示
        timelabel.text = string.Format("Time:{0:00}",timecount);
        //time減少
        timecount -= Time.deltaTime;
        //timeループ
        if (timecount <= 0.0f)
        {
            //Start(); 今は邪魔なのでコメントアウト

            //ポイント数
            FindObjectOfType<score>().countpoint(100);
        }
    }
}
