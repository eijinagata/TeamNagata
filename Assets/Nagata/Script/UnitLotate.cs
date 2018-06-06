using System.Collections;
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
    public float LoteSpeed;//回転スピードを設定できる変数。
    float Rot = 90.0f;
    public ParticleSystem particle;//パーティクルを格納するための器
    bool startRot;//今このユニットが回転中かどうかのフラグ
    public bool GetAccessflag()//今回転中かのフラグのゲットアクセサ
    {
        return startRot;
        particle = this.GetComponent<ParticleSystem>();
    }

    public void RotateCom()
    {
        if (Input.GetMouseButtonDown(0) /* && !startRot*/&&Accessflag==true)
        {
            //startRot = true;
            particle.Play();
            transform.rotation = Quaternion.AngleAxis(Rot, Vector3.up);
            Rot += 90;
        }

       /* if (startRot)
        {
           /* time += Time.deltaTime;//timeにdeltaTimeを加算
            kakudo = Mathf.Lerp(degStart, degEnd, time * LoteSpeed);//degStart地点からdegEnd地点まで時間×～倍速で回転させる。*/
           // transform.rotation = Quaternion.AngleAxis(kakudo, Vector3.up);//kakudo分右に回転させる処理。
            /*if (kakudo >= RotlLimit)
            {
                startRot = false;
                time = 0;
                degStart += 90;
                degEnd += 90;
                RotlLimit += 90;
            }
        }*/
    }
    private void Access()//マウスが一本道のコライダーに入った時
    {
        Accessflag = true;
    }
    private void Escape()//マウスが一本道のコライダーより離れたとき
    {
        Accessflag = false;
    }
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        RotateCom();//メソッド、RotateComを実行。
        Debug.Log(Accessflag);
    }
}
