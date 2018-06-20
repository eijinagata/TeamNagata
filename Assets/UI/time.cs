using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class time : MonoBehaviour {

    //time変数
    public float timecount;
    public Text timelabel;
    bool saveFlg = false;

    public float TIME
    {
        get { return timecount; }
    }

	// Use this for initialization
    public void Start () {
        //制限時間
        timecount = 3;
        // 書き込むファイルを指定
        TajimaStream.SetFileName("Assets\\ScoreData\\score.txt");
        saveFlg = false;

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
            // 制限時間が終わったので、スコアを保存する
            // 一度だけ保存したいからフラグで管理
            if(saveFlg == false)
            {
                // 保存したいデータを追加する
                TajimaStream.AddData(FindObjectOfType<score>().GetScore().ToString());
                // 追加したデータを実際にファイルに書き込む
                TajimaStream.Save();
                saveFlg = true;
            }
        }
        else
        {
            //AddScore呼出し
            FindObjectOfType<score>().AddScore(1);
        }
    }
}
