using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationMove : MonoBehaviour {
    
    int value = 0;          //何度回転したかカウントしておく
    bool flag = false;      //今上がってる？下がってる？
    bool moveFlag = false;  //起動中か否かを判断
    Vector3 defaultPos;     //最初にいた位置を覚えておく変数
    Vector3 jump;           //ジャンプ力
    float speed = 2.0f;
    
    // Use this for initialization
    void Start ()
    {
        moveFlag = false;
        defaultPos = transform.position;        //自分の位置を保存
        jump = new Vector3(0.0f, 0.25f, 0.0f);   //ジャンプ力を設定
    }
	
	// Update is called once per frame
	void Update ()
    {
        //仮アクション
        if (Input.GetMouseButtonDown(0) && moveFlag == false)
        {
            value = 0;          //初期化
            moveFlag = true;    //起動開始    
        }

        //アクションが起こったら90度回転
        if (moveFlag == true)
        {
            if (value < 90 / speed)
            {
                value++;    //乗算
                transform.Rotate(new Vector3(0, speed, 0)); //徐々に回転

                ////45度傾くまで上昇
                //if (value <= 90 - 45 /*&& flag == false*/)
                //{
                //    //transform.position += jump;
                //}
                //else if (value > 90 - 45)
                //{
                //    flag = true;
                //}

                ////45度を越えると落下
                //if (flag == true)
                //{
                //    //transform.position -= jump;
                //}

                ////高さが元いた高さより低くなったら挙動を停止し、元いた高さに戻る
                ////if (transform.position.y <= defaultPos.y && flag == true)
                ////{
                //    moveFlag = false;
                //    flag = false;
                //    transform.position = defaultPos;
                ////}
            }
            else
            {
                moveFlag = false;
            }
        }
	}

    public void rotation()
    {
        if (moveFlag == false)
        {
            value = 0;          //初期化
            moveFlag = true;    //起動開始    
        }
    }
}
