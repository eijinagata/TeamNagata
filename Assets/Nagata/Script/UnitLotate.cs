﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitLotate : MonoBehaviour {

    public float time;//時間をはかる変数。
    bool Accessflag = false;//このユニットにマウスが当たっているかどうかのフラグ。
    Quaternion a = Quaternion.AngleAxis(0, Vector3.up);
    Quaternion b = Quaternion.AngleAxis(90, Vector3.up);

    float kakudo = 0f;//今の角度
    float degStart = 0f;//Lerp回転の開始地点。
    float degEnd = 90f;//Lerp回転の終了地点。
    float RotlLimit = 90f;//一回のメソッドの実行でこの角度まで回るという角度限界

    bool startRot = false;//今このユニットが回転中かどうかのフラグ
    public bool GetAccessflag()//今回転中かのフラグのゲットアクセサ
    {
        return startRot;
    }
    public void RotateCom()
    {
        if (Input.GetMouseButtonDown(0) && !startRot&&Accessflag==true)
        {
            startRot = true;
        }

        if (startRot)
        {
            time += Time.deltaTime;//timeにdeltaTimeを加算
            kakudo = Mathf.Lerp(degStart, degEnd, time * 5f);//degStart地点からdegEnd地点まで時間×～倍速で回転させる。
            transform.rotation = Quaternion.AngleAxis(kakudo, Vector3.up);
            if (kakudo >= RotlLimit)
            {
                startRot = false;
                time = 0;
                degStart += 90;
                degEnd += 90;
                RotlLimit += 90;
            }
        }
    }
    public void Access()//マウスが一本道のコライダーに入った時
    {
        Accessflag = true;
    }
    public void Escape()//マウスが一本道のコライダーより離れたとき
    {
        Accessflag = false;
    }
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        RotateCom();
	}
}
