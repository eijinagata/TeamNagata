using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move3 : MonoBehaviour
{
    int countr;             //何回壁に当たったかを記録する変数
    int fps = 0;            //何フレーム経ったかを覚えておく変数
    float distance = 1.5f;  //Rayの長さ
    float speed = 0.1f;     //移動速度
    bool frameFlag = false; //フレームを計っていいかダメかを判断するフラグ
    bool moveFlag = true;   //動いていいかダメかを判断するフラグ
    bool unitFlag = false;  //親オブジェクトが動いてる？動いてない？を判断するフラグ
    GameObject gameObj;     //当たったオブジェクトを覚えておく変数
    UnitLotate uniLot;      //UnitLotate内の変数が欲しいので宣言

    public void PlusSpeed(float value)
    {
        speed = speed + value;
    }

    void RayMove()
    {
        //Rayの作成　　　　　　　↓Rayを飛ばす原点　　　↓Rayを飛ばす方向
        Ray ray = new Ray(transform.position, transform.forward);

        //Rayが当たったオブジェクトの情報を入れる箱
        RaycastHit hit;

        //もしRayにオブジェクトが衝突したら
        //                  ↓Ray  ↓Rayが当たったオブジェクト ↓距離
        if (Physics.Raycast(ray, out hit, distance))
        {
            //Debug.Log("まん丸お山に彩を");
            if (hit.collider.gameObject.tag == "Wall")
            {
                moveFlag = false;
                //Debug.Log("壁に当たった");
                switch(countr)
                {
                    case 0:
                        transform.Rotate(new Vector3(0.0f, 90.0f, 0.0f));
                        distance = distance + 1;
                        countr++;
                        break;
                    case 1:
                        transform.Rotate(new Vector3(0.0f, 180.0f, 0.0f));
                        countr++;
                        //Debug.LogError("１８０度回転してます");
                        break;
                    case 2:
                        Destroy(gameObject);
                        break;
                    default:
                        break;
                }
            }
        }
        else
        {
            distance = 1;       //Rayの長さを元に戻す
            countr = 0;         //カウンターをリセット
            moveFlag = true;    //起動開始
        }
    }

    // Use this for initialization
    void Start ()
    {
        uniLot = FindObjectOfType<UnitLotate>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        //ステージに衝突したら
        //if (uniLot != null)
        //{
        //    //回ってる？回ってない？確認フラグを代入
        //    unitFlag = uniLot.GetAccessflag();
        //}
        
        //モジュールが回ってなくて
        if (uniLot.LOTATE==false&&frameFlag==false)
        {
            RayMove();

            //Rayが何にもぶつかってなかったら
            if (moveFlag == true)
            {               
                //RayMove();
                transform.position += transform.TransformDirection(Vector3.forward) * speed;
            }
        }

        //縁取りに衝突したらフレームを計る
        if (frameFlag == true)
        {
            fps++;

            //300フレーム動いたらこのオブジェクトを消す
            if (fps == 300)
            {
                Destroy(gameObject);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        //モジュールが回ってなくて
        if (uniLot.LOTATE == false)
        {
            //タグがStageのオブジェクトに衝突したら
            if (other.gameObject.tag == "Stage")
            {
                //親離れする
                transform.parent = null;

                transform.parent = other.gameObject.transform;

                uniLot = other.gameObject.GetComponent<UnitLotate>();
                ////当たったオブジェクトを代入
                //gameObj = other.gameObject; 

                //////当たったオブジェクトについているUnitLotateを取得
                ////uniLot = gameObj.GetComponent<UnitLotate>();

                ////侵入したステージの子オブジェクトに
                //transform.parent = gameObj.transform; 
            }
        }

        //外の縁取りに当たったら
        if (other.gameObject.tag == "DestroyObj")
        {
            //親離れする
            transform.parent = null;

            //フレームをカウント開始
            frameFlag = true;

            speed = 0.01f;
        }
    }
}
