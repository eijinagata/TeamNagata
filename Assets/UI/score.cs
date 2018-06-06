using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class score : MonoBehaviour {

    //スコア変数
    int scorecount;
    public Text scorelabel;
    
    void Start()
    {
        //スコア初期化
        scorecount = 0;

    }
    // Update is called once per frame
    void Update()
    {
        //スコア表示
        scorelabel.text = string.Format("Score：{0:0000}", scorecount);
        

    }
    //スコア加算
    public void countpoint(int point)
    {
        scorecount = scorecount + point;
       
    }

}
