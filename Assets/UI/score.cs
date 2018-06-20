using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class score : MonoBehaviour { 

    //スコア変数
    float scorecount;
    float Threeharf;
    public Text scorelabel;
    //ポイント固定値
    const int SCORE_POINT = 100;

    public float GetScorecount()//スコアのゲットアクセサ
    {
        return scorecount;
    }
    public void SetEnemyGoalScore(int Enemy)
    {
        Threeharf = scorecount;
        Threeharf /= Enemy;
        scorecount -= Threeharf;
    }
    
    void Start()
    {
        //スコア初期化
        scorecount = 0.0f;

    }
    // Update is called once per frame
    void Update()
    {
        //スコア表示
        scorelabel.text = string.Format("{0:00000}", scorecount);//永田スコアを削除
        

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
