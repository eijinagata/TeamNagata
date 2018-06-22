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
    UnitLotate uniLot;
    pauseController button;
   
	// Use this for initialization
	void Start ()
    {
        //button = FindObjectOfType<pauseController>();
        timeScript = FindObjectOfType<time>();
        //uniLot = FindObjectOfType<UnitLotate>();
    }
	
	// Update is called once per frame
	void Update()
    {
        //time = timeScript.GetTimecount();
        uniLot = FindObjectOfType<UnitLotate>();
        if (uniLot.LOTATE == false)
        {
            shootTime += Time.deltaTime;
        }

        if (shootTime > 0.5f)
        {
            moveFlag = false;
        }

        if (time > 0 /*&& Input.GetKeyDown(KeyCode.Space)*/ && shootTime > 0.5f )
        {
            shootTime = 0.0f;
            ball.transform.position = transform.position;
            ball.transform.forward = transform.forward;
            Instantiate(ball);
            //Debug.Log("発射");
        }
    }
}
