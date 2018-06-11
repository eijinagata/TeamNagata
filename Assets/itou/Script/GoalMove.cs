using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalMove : MonoBehaviour {

    int score;

	// Use this for initialization
	void Start ()
    {
        score = 100;    //仮のスコア	
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Ball")
        {
            //Debug.LogError("頂点へ狂い咲け");
            Destroy(other.gameObject);
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
