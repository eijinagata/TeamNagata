using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move2 : MonoBehaviour {
    
    int hitCoumt = 0;       //何回壁に衝突したか記録しておく
    float rayLength = 1.5f; //Rayの長さ
    float distance;         //Rayの飛ばせる距離
    float speed = 0.05f;    //このオブジェクトのスピード
    bool flag = false;      //このオブジェクトが壁に当たったかどうか
    bool crossFlag;
    CrossUnit crossUnit;

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
            //壁に当たったら
            if (hit.collider.tag == "Wall")
            {
                Debug.Log("壁に衝突");
                flag = true;               //衝突した
                hitCoumt++;                //カウンターをカウント
                distance = distance * 2;   //Rayの飛ばせる距離

                //1回目は右を、2回目は左を、三回目は行き止まりに入ったことになるので削除
                switch (hitCoumt)
                {
                    case 1:
                        transform.Rotate(new Vector3(0, 90, 0));
                        break;
                    case 2:
                        transform.Rotate(new Vector3(0, 180, 0));
                        break;
                    case 3:
                        Destroy(gameObject);
                        break;
                    default:
                        break;
                }
            }
        }
        else
        {
            hitCoumt = 0;           //カウンターを初期化
            distance = rayLength;   //例の長さを元に戻す
            flag = false;           //衝突終了
        }
    }
    
    // Use this for initialization
    void Start ()
    {
        distance = rayLength;
	}
	
	// Update is called once per frame
	void Update ()
    {
        RayMove();
        if (crossUnit != false)
        {
            Debug.Log("起動したじぇ");
            crossFlag = crossUnit.GetIslotate();
            Debug.Log("crossFlag="+crossFlag);
        }
        //Rayが壁に衝突するまで動く
        if (flag == false)
        {
            transform.position += transform.TransformDirection(Vector3.forward) * speed;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Stage")
        {
            //Debug.Log("どこかのステージに侵入");
            GameObject gameObj = other.gameObject;
            crossUnit = gameObj.GetComponent<CrossUnit>();
            transform.parent = gameObj.transform; //侵入したステージの子オブジェクトに
        }

        if (other.gameObject.tag == "Goal")
        {
            //Debug.Log("ゴールに到達");
            Destroy(gameObject);
        }
    }
}