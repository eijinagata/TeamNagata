using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnObjectController : MonoBehaviour {

    public GameObject enemy;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetMouseButtonDown(0))
        {
            enemy.transform.position = transform.position;
            enemy.transform.forward = transform.forward;
            Instantiate(enemy);
        }
    }
}
