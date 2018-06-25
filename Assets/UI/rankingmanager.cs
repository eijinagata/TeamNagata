using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class rankingmanager : MonoBehaviour {
    int newscore = 0;       // 今回のプレイのスコア
    int changeScore = 3;    // ランキングのどこの桁ハイスコアとして更新されたかを保存する。ランク外で初期化
    List<int> rankscore = new List<int>();// ランキング１～３位＋今回のスコアの数値を保存
    public Text rank1text;  // ランク1位のテキスト
    public Text rank2text;  // ランク2位のテキスト
    public Text rank3text;  // ランク3位のテキスト
                            // Use this for initialization
    void Start () {
        // ランキングのテキストを読み込む設定
        TajimaStream.SetFileName("Assets\\ScoreData\\ranking.txt");
        // ファイルを読み込む。ついでに段落ごとに分割して配列に保存
        string[] str = TajimaStream.Load().Split('\n');
        // ランキング用のリストに読み込んだランキングテキストの値を保存
        for (int i = 0; i < 3; i++)
        {
                rankscore.Add(int.Parse(str[i]));
        }
        // 今回のプレイのスコアを読み込む設定
        TajimaStream.SetFileName("Assets\\ScoreData\\score.txt");
        // 値を保存
        newscore = int.Parse(TajimaStream.Load());
        // ランキング用のリストの一番後ろ（4番目）に値を追加する
        rankscore.Add(newscore);
        // 降順でソート
        rankscore.Sort((a, b) => b - a);
        // 今回のプレイのスコアが１～３位に入ったかを確認する
        for (int i = 0; i < 3; i++)
        {
            if(rankscore[i] == newscore)
            {
                changeScore = i;// ランクが更新されたのはこの位置
            }
        }

        // ランキングのテキストを書き込む設定
        TajimaStream.SetFileName("Assets\\ScoreData\\ranking.txt");
        for (int i = 0; i < 3; i++)
        {
            // １～３位を順番に保存データとして追加する
            TajimaStream.AddData(rankscore[i].ToString());
        }
        // 実際にファイルに書き込む
        TajimaStream.Save();
    }

    // Update is called once per frame
    void Update () {
        rank1text.text = rankscore[0].ToString();
        rank2text.text = rankscore[1].ToString();
        rank3text.text = rankscore[2].ToString();
        // 確認のために値が変更された箇所を赤色のフォントにしている
        switch(changeScore)
        {
            case 0:
                rank1text.color = Color.red;
                break;
            case 1:
                rank2text.color = Color.red;
                break;
            case 2:
                rank3text.color = Color.red;
                break;
        }

    }
}
