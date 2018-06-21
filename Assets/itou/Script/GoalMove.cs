﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalMove : MonoBehaviour {

    int score;
    int penalty;
    score Score;
    combo GetCombo;
    public GameObject ScoreCount;//スコアカウントが入る変数。

	// Use this for initialization
	void Start ()
    {
        Score = ScoreCount.GetComponent<score>();
        GetCombo = ScoreCount.GetComponent<combo>();
        //publicにしてインスペクターから入れなくてもstartで代入できます
        //ScoreCount = GameObject.Find("UIController");

        //なぜかUpdate内で行われているGetComponentがありますが、Start内でこんな感じで書けますよ
        /*
        //パターン１
        Score = GameObject.Find("UIController").GetComponent<score>();
        GetCombo= GameObject.Find("UIController").GetComponent<combo>();

        //パターン２
        Score = FindObjectOfType<score>();
        GetCombo = FindObjectOfType<combo>();
        */
    }

    // Update is called once per frame
    void Update () {

	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Ball")
        {
            Score.AddScore(GetCombo.ComboCount());
            GetCombo.active();
            Destroy(other.gameObject);
            

        }

        if (other.gameObject.tag == "Enemy")
        {
            Score.SetEnemyGoalScore(3);
            GameObject hitObj = other.gameObject;
            EnemyMove enemyMove = hitObj.GetComponent<EnemyMove>();
            enemyMove.DATE--;
            Destroy(other.gameObject);
        }
    }
}
