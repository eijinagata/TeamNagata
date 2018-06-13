using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class score : MonoBehaviour { 

    //スコア変数
    float scorecount;
    public Text scorelabel;
    //ポイント固定値
    const int SCORE_POINT = 100;
    
    void Start()
    {
        //スコア初期化
        scorecount = 0.0f;

    }
    // Update is called once per frame
    void Update()
    {
        //スコア表示
        scorelabel.text = string.Format("Score：{0:00000}", scorecount);
        

    }
    //スコア加算
    public void AddScore(int combo)
    {
        //コンボ倍率
        float com=(1.0f+((1.0f+combo)/10.0f))-0.1f;
        //ポイント値*コンボ倍率
        scorecount += SCORE_POINT * com;
        //Debug.Log(scorecount);
    }

}
