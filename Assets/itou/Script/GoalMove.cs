using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalMove : MonoBehaviour {

    int score;
    int penalty;
    score Score;
    public GameObject ScoreCount;//スコアカウントが入る変数。

	// Use this for initialization
	void Start ()
    {
        score = 100;    //仮のスコア
        penalty = 500;  //仮のペナルティ	
	}
	
	// Update is called once per frame
	void Update () {
        Score = ScoreCount.GetComponent<score>();
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Ball")
        {
            Destroy(other.gameObject);
            Score.AddScore(combo);

        }

        if (other.gameObject.tag == "Enemy")
        {
            GameObject hitObj = other.gameObject;
            EnemyMove enemyMove = hitObj.GetComponent<EnemyMove>();
            enemyMove.DATE--;
            Destroy(other.gameObject);
        }
    }
}
