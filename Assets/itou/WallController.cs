using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallController : MonoBehaviour
{
    Renderer rend;
    float alpha;            //アルファ値をいじる用の変数
    float minAlpha = 0.2f;  //最小の薄さ
    float maxAlpha = 0.6f;  //最大の濃さ
    float speed = 0.005f;   //フィードインフィードアウトのスピード
    bool alphaFlag = false;

    // Use this for initialization
    void Start()
    {
        alpha = maxAlpha;

        rend = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        //薄くするか濃くするか
        if (alphaFlag == false)
        {
            alpha -= speed;
        }
        else
        {
            alpha += speed;
        }

        //薄くするべきか濃くするべきか
        if (alpha < minAlpha)
        {
            alphaFlag = true;
        }
        else if (alpha > maxAlpha)
        {
            alphaFlag = false;
        }

        //RGBαを更新
        rend.material.color = new Color(1f, 0f, 0f, alpha);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Ball")
        {
            Destroy(other.gameObject);
            Debug.Log("ボールが壁に当たって消滅");
        }
    }
}
