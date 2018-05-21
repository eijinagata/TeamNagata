using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallCreate : MonoBehaviour {
    public GameObject ball;

    Vector3 defaultPos;
	// Use this for initialization
	void Start ()
    {
       
	}
	
	// Update is called once per frame
	void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            ball.transform.position = transform.position;
            ball.transform.forward = transform.forward;
            Instantiate(ball);
        }
    }
}
