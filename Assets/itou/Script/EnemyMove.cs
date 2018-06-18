using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    int countr;             //何回壁に当たったかを記録する変数
    //int hitCountr;          //何回ボールに当たったかを記録する変数
    public int maxEnemy;    //フィールドに存在できるエネミーの上限
    static int date = 0;    //今ゲーム内に何体敵がいるかを記録する変数
    float distance = 1.5f;  //Rayの長さ
    float speed = 0.1f;     //移動速度
    bool moveFlag = true;   //動いていいかダメかを判断するフラグ
    bool unitFlag = false;  //親オブジェクトが動いてる？動いてない？を判断するフラグ
    GameObject gameObj;     //当たったオブジェクトを覚えておく変数
    UnitLotate uniLot;      //UnitLotate内の変数が欲しいので宣言
    public GameObject my;   //自分を覚えるための変数

    // Use this for initialization
    void Start()
    {
        date++;
        uniLot = FindObjectOfType<UnitLotate>();
    }

    //変数名dateにアクセスしたいときに使う
    public int DATE
    {
        get { return date; }
        set { date = value; }
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
            if (hit.collider.gameObject.tag == "DestroyObj")
            {
                transform.Rotate(new Vector3(0.0f, 180.0f, 0.0f));
            }

            if (hit.collider.gameObject.tag == "Wall")
            {
                moveFlag = false;

                switch (countr)
                {
                    case 0:
                        transform.Rotate(new Vector3(0.0f, 90.0f, 0.0f));
                        distance = distance + 1;
                        countr++;
                        break;
                    case 1:
                        transform.Rotate(new Vector3(0.0f, 180.0f, 0.0f));
                        countr++;
                        break;
                    case 2:
                        transform.Rotate(new Vector3(0.0f, 270.0f, 0.0f));
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



    // Update is called once per frame
    void Update()
    {
        //ステージに衝突したら
        if (gameObj != null)
        {
            //回ってる？回ってない？確認フラグを代入
            //unitFlag = uniLot.GetAccessflag();
            uniLot = FindObjectOfType<UnitLotate>();
        }
        uniLot = FindObjectOfType<UnitLotate>();
        //モジュールが回ってなくて
        if (uniLot.LOTATE == false)
        {
            RayMove();

            //Rayが何にもぶつかってなかったら
            if (moveFlag == true)
            {
                //RayMove();
                transform.position += transform.TransformDirection(Vector3.forward) * speed;
            }
        }

        //if (date >= maxEnemy)
        //{
        //    hitCountr = 0;
        //}

        ////十回ボールに当たったら分身を生成
        //if (hitCountr == 10 && date < maxEnemy)
        //{
        //    moveFlag = false;
        //    my.transform.parent = null;
        //    Instantiate(my, transform.position, Quaternion.identity);
        //    moveFlag = true;
        //    hitCountr = 0;
        //}
    }

    private void OnTriggerEnter(Collider other)
    {
        //モジュールが回ってなくて
        //if (/*unitFlag == false*/uniLot.LOTATE == false)
        //{
        //タグがStageのオブジェクトに衝突したら
        if (other.gameObject.tag == "Stage")
        {
            //当たったオブジェクトを代入
            gameObj = other.gameObject;

            ////当たったオブジェクトについているUnitLotateを取得
            //uniLot = gameObj.GetComponent<UnitLotate>();

            //侵入したステージの子オブジェクトに
            transform.parent = gameObj.transform;
        }
        //}

        //ボールにぶつかったら
        if (other.gameObject.tag == "Ball")
        {
            //hitCountr++;
            Destroy(other.gameObject);
        }
    }
}