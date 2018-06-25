using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {
    int score;
    GameObject Scoree;

    void Start () {
        Scoree = GameObject.Find("Score");
         score = TheCount.Total();
    }

    void Update () {
        Scoree. GetComponent<Text>().text = "結果 : " + score.ToString("00000000");
    }
}
