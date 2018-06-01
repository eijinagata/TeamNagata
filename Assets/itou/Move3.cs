using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move3 : MonoBehaviour {

    int countr;
    float distance = 1.0f;
    float speed = 0.1f;
    bool moveFlag = true;
    bool flag = false;
    bool nextFlag = false;
    GameObject gameObj;
    UnitLotate uniLot;
    UnitLotate nextUniLot;

    int i = 0;

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
                Debug.Log("壁に当たった");
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

        //Rayを可視化　色は緑
        Debug.DrawRay(transform.position, transform.forward * 5, Color.green, 1, true);
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        //ステージに衝突したら
        if (gameObj != null)
        {
            //回ってる？回ってない？確認フラグを代入
            flag = uniLot.GetAccessflag();
        }
        //Debug.Log(flag);
        
        //モジュールが回ってなくて
        if (flag == false)
        {
            RayMove();
            //Rayが何にもぶつかってなかったら
            if (moveFlag == true)
            {               
                //RayMove();
                transform.position += transform.TransformDirection(Vector3.forward) * speed;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        //モジュールが回ってなくて
        if (flag == false)
        {
            //タグがStageのオブジェクトに衝突したら
            if (other.gameObject.tag == "Stage")
            {
                Debug.LogError("でねーじゃなーか紅玉よぉぉぉ！！");
                
                //当たったオブジェクトを代入
                gameObj = other.gameObject; 

                //当たったオブジェクトについているUnitLotateを取得
                uniLot = gameObj.GetComponent<UnitLotate>();

                //侵入したステージの子オブジェクトに
                transform.parent = gameObj.transform; 
            }
        }
    }
}
