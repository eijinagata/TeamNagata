using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TheCount : MonoBehaviour {

    static int point = 0; //獲得したスコア
    GameObject Text; //表示用

	void Start () {
        Text = GameObject.Find("Point"); //表示用
        point = 0; //リセット
    }

	void Update () {
        this.Text.GetComponent<Text>().text = point.ToString();	//Textで表示してるスコアの更新
	}

    /// <summary>
    /// 加算用
    /// </summary>
    public void plus() 
    {
        point += 1;
    }

    /// <summary>
    /// リザルトシーンでスコア伝える用
    /// </summary>
    /// <returns></returns>
    public static int Total()
    {
        return point;
    }
}
