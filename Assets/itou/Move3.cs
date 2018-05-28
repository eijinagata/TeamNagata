using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move3 : MonoBehaviour {

    int countr;
    float distance = 1.0f;
    float speed = 0.05f;
    bool moveFlag = false;

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
            Debug.Log("まん丸お山に彩を");
            if (hit.collider.gameObject.tag == "Wall")
            {
                moveFlag = true;
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
                        break;
                    case 2:
                        Destroy(gameObject);
                        break;
                    default:
                        break;
                }
            }
            else
            {
                //distance = 1;
                countr = 0;
                //moveFlag = false;
            }
        }
        else
        {
            distance = 1;
            countr = 0;
            moveFlag = false;
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
        RayMove();
        if(moveFlag==false)
        transform.position += transform.TransformDirection(Vector3.forward) * speed;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Stage")
        {
            GameObject gameObj = other.gameObject;
            transform.parent = gameObj.transform; //侵入したステージの子オブジェクトに
        }
    }
}
