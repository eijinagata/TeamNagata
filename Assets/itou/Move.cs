using UnityEngine;
using System.Collections;

public class Move : MonoBehaviour
{
    float speed = 0.05f;    //このオブジェクトのスピード
    float timer = 0.0f;     //衝突してからの時間を計る用のタイマー
    int count = 0;          //何回壁に当たったかをカウントしておくカウンタ―

    bool collisionFlag = false; //衝突検知フラグ

    BoxCollider boxCollider;
    Vector3 boxColliderSize = new Vector3(0.5f, 0.5f, 2.5f);
    Vector3 defaultSize;

    void Start()
    {
        boxCollider = GetComponent<BoxCollider>();  //自分についているBoxColliderを取得
        defaultSize = boxCollider.size;             //デフォルトの大きさを保存
    }

    void Update()
    {
        //向いている方向に移動
        if (collisionFlag == false)
        {
            transform.position += transform.TransformDirection(Vector3.forward) * speed;
        }

        //壁に当たったら時間を計る
        if (collisionFlag == true)
        {
            timer += Time.deltaTime;
        }
       
        //行き止まりになったら消滅
        if (count >= 4)
        {
            Destroy(gameObject);
        }

        //壁に当たってから0.05秒たったら時間を計ることをやめて、タイマーをリセット
        if (timer > 0.05)
        {
            boxCollider.size = defaultSize; //センサーを元に戻す
            collisionFlag = false;          //フラグをオフに
            timer = 0;                      //タイマーをリセット
            count = 0;                      //カウンターをリセット
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        //壁に当たったら向いている方向から90度回転(右を向く)し、タイマーを起動
        if (other.gameObject.tag == "Wall" && collisionFlag == false)
        {
            Debug.Log("90度回転");
            transform.Rotate(new Vector3(0, 90, 0));
            boxCollider.size = boxColliderSize; //センサーを大きく伸ばす
            collisionFlag = true;
            count++;
        }

        if (other.gameObject.tag == "Stage")
        {
            //Debug.Log("どこかのステージに侵入");
            GameObject gameObj = other.gameObject;
            transform.parent = gameObj.transform; //侵入したステージの子オブジェクトに
        }
    }

    private void OnTriggerStay(Collider other)
    {
        //一度壁に当たってからまだ壁に当たっていた場合180回転（左を向く）
        if (other.gameObject.tag == "Wall" && collisionFlag == true)
        {
            Debug.Log("180度回転");
            transform.Rotate(new Vector3(0, 180, 0));
            timer = 0;
            count++;
        }
    }
}