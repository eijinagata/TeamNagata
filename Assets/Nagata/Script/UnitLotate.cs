using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnitLotate : MonoBehaviour {

    /// <summary>
    /// フィールドここから！
    /// </summary>
    /// 

    Renderer rend;//アタッチされたユニットのレンダラーを取得。
    float red, green, blue, alpha;  //RGBα用の変数


    public float time;//時間をはかる変数。

    bool Accessflag = false;//このユニットにマウスが当たっているかどうかのフラグ。

    Quaternion a = Quaternion.AngleAxis(0, Vector3.up);
    Quaternion b = Quaternion.AngleAxis(90, Vector3.up);

    public Text HeatLeveltext;

    float kakudo = 0f;//今の角度

    float degStart = 0f;//Lerp回転の開始地点。

    float degEnd = 90f;//Lerp回転の終了地点。

    float RotlLimit = 90f;//一回のメソッドの実行でこの角度まで回るという角度限界

    public float LoteSpeed;//回転スピードを設定できる変数。

    float Rot = 90.0f;//一度に回転する角度。

    public ParticleSystem LoteParticle;//回転時発動パーティクルを格納するための器

    public ParticleSystem OverHeatSmog;//オーバーヒート時の煙

    bool startRot;//今このユニットが回転中かどうかのフラグ

    bool OverHeatflag = false;//オーバーヒートしているかどうかのフラグ

    float HeatLevel = 1;//今どれだけオーバーヒートに近づいているかの数値

    bool isCoolDoun = false;//今クールタイムに入っているかどうかのフラグ
    /// <summary>
    /// フィールドここまで！！
    /// </summary>
    /// <returns></returns>

    public float GetHeatLevel()//デバッグ用テキストを表示させるためのGETアクセサ
    {
        return HeatLevel;
    }


    public bool GetAccessflag()//今回転中かのフラグのゲットアクセサ
    {
        return startRot;
    }

    public void OverHeat()//オーバーヒートさせる処理
    {
        
        if (HeatLevel <= 1.0f)//HeatLevelが0になるまで常時タイム分だけプラスする。
        {
           HeatLevel += Time.deltaTime*0.2f;
        }

        if (HeatLevel >= 1.0f)//HeatLevelの値が0になった場合、OverHeatflagはfalseになる。
        {
            OverHeatflag = false;
            isCoolDoun = false;
            HeatLevel = 1.0f;
        }

        if (HeatLevel <= 0.0f&&OverHeatflag==false)//HeatLevelが５以上になった場合、オーバーヒートして冷えるまでユニットが停止する。
        {
            OverHeatflag = true;
            isCoolDoun = true;
        }
        if (isCoolDoun == false)
        {

        }
        if (isCoolDoun == true)
        {
            OverHeatSmog.Play();
        }
    }

    public void HeatRender()
    {
        blue = HeatLevel;
        green = HeatLevel;
        rend.material.color = new Color(red, green, blue, alpha);

    }

    public void RotateCom()//ユニットを押すたびに90度回転させる処理。
    {
        if (Input.GetMouseButtonDown(0) /* && !startRot*/&& Accessflag == true && OverHeatflag == false)
        {
            //startRot = true;
            if (isCoolDoun == false)//オーバーヒートするまでHeatLevelに1を加算
            {
                HeatLevel-=0.2f;
            }
            LoteParticle.Play();//パーティクル発動！！
            transform.rotation = Quaternion.AngleAxis(Rot, Vector3.up);
           
            Rot += 90;
        }
        if (Input.GetMouseButtonDown(1) /* && !startRot*/&& Accessflag == true && OverHeatflag == false)
        {
            //startRot = true;
            if (isCoolDoun == false)//オーバーヒートするまでHeatLevelに1を加算
            {
                HeatLevel -= 0.2f;
            }
            LoteParticle.Play();//パーティクル発動！！
            transform.rotation = Quaternion.AngleAxis(Rot, Vector3.up);

            Rot -= 90;
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
        //色をいじるためにRendererを取得
        rend = GetComponent<Renderer>();

        //今の色で初期化
        red = rend.material.color.r;
        green = rend.material.color.g;
        blue = rend.material.color.b;
        alpha = rend.material.color.a;
    }
	
	// Update is called once per frame
	void Update () {
        OverHeat();//OverHeatを実行。
        RotateCom();//メソッド、RotateComを実行。
        HeatRender();
    }
}
