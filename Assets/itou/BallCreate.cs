using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallCreate : MonoBehaviour
{
    float time = 0.0f;
    float shootTime = 0.0f;
    public GameObject ball; //発射するオブジェクトを覚えておくための変数
    time timeScript;
    bool moveFlag = false;
   
	// Use this for initialization
	void Start ()
    {
        timeScript = FindObjectOfType<time>();
    }
	
	// Update is called once per frame
	void Update()
    {
        //if (Input.GetKeyDown(KeyCode.Return))
        //{
        //    ball.transform.position = transform.position;
        //    ball.transform.forward = transform.forward;
        //    Instantiate(ball);
        //}

        time = timeScript.GetTimecount();
        if (moveFlag == true)
        {
            shootTime += Time.deltaTime;
        }
        if (shootTime > 0.5f)
        {
            moveFlag = false;
        }

        if (time > 0 && Input.GetKeyDown(KeyCode.Space) && moveFlag == false)
        {
            shootTime = 0.0f;
            ball.transform.position = transform.position;
            ball.transform.forward = transform.forward;
            Instantiate(ball);
            moveFlag = true;
            //Debug.Log("発射");
        }
    }
}
