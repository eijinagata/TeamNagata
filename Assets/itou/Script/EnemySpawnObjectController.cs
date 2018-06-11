using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnObjectController : MonoBehaviour {

    public GameObject enemy;
    EnemyMove enemyMove;

	// Use this for initialization
	void Start ()
    {
        enemyMove = FindObjectOfType<EnemyMove>();	
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (enemyMove.DATE <= 0)
        {
            enemy.transform.position = transform.position;
            enemy.transform.forward = transform.forward;
            Instantiate(enemy);
        }
    }
}
