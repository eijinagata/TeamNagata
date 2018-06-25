using System.Collections;
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
