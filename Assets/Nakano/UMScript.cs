using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UMScript : MonoBehaviour
{

    //ゲームオブジェクトを取得
    public GameObject Title;
    public GameObject ScoreTitle;
    public GameObject Score;
    public GameObject ComboTitle;
    public GameObject Combo;
    public GameObject RankingTitle;
    public GameObject Ranking1;
    public GameObject Ranking2;
    public GameObject Ranking3;
    public GameObject Button1;
    public GameObject Button2;

    //時間のカウント
    float time = 0;
    //時間のリセットに必要
    bool timeflag = true;


    //他のスクリプトを宣言
    public ScoreScript scoreScript;
    public ComboScript comboScript;

    // Use this for initialization
    void Start ()
    {

        //ゲームオブジェクトを非表示
        Title.SetActive(false);
        ScoreTitle.SetActive(false);
        Score.SetActive(false);
        ComboTitle.SetActive(false);
        Combo.SetActive(false);
        RankingTitle.SetActive(false);
        Ranking1.SetActive(false);
        Ranking2.SetActive(false);
        Ranking3.SetActive(false);
        Button1.SetActive(false);
        Button2.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {

        //マネしないように
        bool maxs;
        maxs = scoreScript.MaxS;
        bool maxc;
        maxc = comboScript.MaxC;

        //時間の計算
        time += Time.deltaTime;
        //Debug.Log(time);

        //オブジェクトを時間経過で表示
        if (time > 0.5)
        {
            Title.SetActive(true);
        }
        if(time > 1.0)
        {
            ScoreTitle.SetActive(true);
        }
        if(time > 1.5)
        {
            ComboTitle.SetActive(true);
        }
        if(time > 2.0)
        {
            RankingTitle.SetActive(true);
        }
        if(time > 2.5)
        {
            Score.SetActive(true);
        }
        if(maxs==true)
        {
            Combo.SetActive(true);
        }
        if(maxc==true)
        {
            Ranking1.SetActive(true);

            //時間のリセット
            if(timeflag==true)
            {
                time = 0;
                timeflag = false;
                //Debug.Log("Reset");
            }
        }
        if(time>0.5&&maxc==true)
        {
            Ranking2.SetActive(true);
        }
        if (time > 1.0 && maxc == true)
        {
            Ranking3.SetActive(true);
        }
        if (time > 1.5 && maxc == true)
        {
            Button1.SetActive(true);
            Button2.SetActive(true);
        }

    }
}
