using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalScript2 : MonoBehaviour
{
    float timecount = 5;//次の位置へ移動するまでのディレイ
    int _frame = 0;//点滅させる為の値
    bool swich;//わざと

    // Use this for initialization
    void Start()
    {
        //int rdmz = UnityEngine.Random.Range(0, 3);

        Vector3 pos = transform.position;

        int rdmx = UnityEngine.Random.Range(-2, 1);

        pos.z = 30;
        pos.x = rdmx;

        transform.position = pos;

        /*  初期位置は上の為コメントアウト
         * if(rdmx==-3)
         {
             pos.x = rdmx * 10;
             pos.z = rdmz * 10;
             transform.position = pos;
         }
         else
         {
             pos.z = 30;
             pos.x = rdmx * 10;
             transform.position = pos;
         }
         */
    }

    // Update is called once per frame
    void Update()
    {

        float root = transform.localEulerAngles.y;
        //オブジェクトの向きを取得

        if(Input.GetKeyDown(KeyCode.B))//Bを押したら点滅&次の位置へ移動
        {
            swich = true;
        }

        if (swich==true)
        {
            timecount -= Time.deltaTime;
            _frame++;

            if (_frame / 30 % 2 == 0)//点滅させる処理
            {
                Renderer ren = gameObject.GetComponent<Renderer>();
                ren.enabled = false;
            }
            else
            {
                Renderer ren = gameObject.GetComponent<Renderer>();
                ren.enabled = true;
            }

            if (timecount < 0)//移動させる処理
            {
                Renderer ren = gameObject.GetComponent<Renderer>();//レンダラーをtrueにしないと消えたままなのでtrueを返す
                ren.enabled = true;

                Vector3 pos = transform.position;

                int rdmz = UnityEngine.Random.Range(0, 3);

                int rdmx = UnityEngine.Random.Range(-3, 1);

                timecount = 5;

                swich = false;

                if (rdmx == -3)
                {
                    pos.x = rdmx * 10;
                    pos.z = rdmz * 10;

                    transform.position = pos;

                    if (root == 0)
                    {
                        //向きが0の時90度回転
                        transform.Rotate(0, 90, 0);
                    }
                }

                else
                {
                    pos.z = 30;
                    pos.x = rdmx * 10;

                    transform.position = pos;

                    timecount = 5;

                    swich = false;

                    if (root == 90)
                    {
                        //向きが90の時0に戻す
                        transform.Rotate(0, -90, 0);
                    }
                }
            }
        }
    }
}