using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallController : MonoBehaviour
{
    Renderer rend;
    GameObject hitGameObj;
    Rigidbody rigidbody;
    float alpha;            //アルファ値をいじる用の変数
    float minAlpha = 0.2f;  //最小の薄さ
    float maxAlpha = 0.6f;  //最大の濃さ
    float speed = 0.005f;   //フィードインフィードアウトのスピード
    float red, green, blue;
    bool alphaFlag = false;

    // Use this for initialization
    void Start()
    {
        alpha = maxAlpha;

        rend = GetComponent<Renderer>();

        red = rend.material.color.r;
        green = rend.material.color.g;
        blue = rend.material.color.b;
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
        rend.material.color = new Color(red, green, blue, alpha);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Ball")
        {
            //ボールが当たったらUseGravityにチェックをいれFreezePositionY以外にチェックをいれる
            hitGameObj = other.gameObject;
            rigidbody = hitGameObj.GetComponent<Rigidbody>();
            rigidbody.useGravity = true;
            rigidbody.constraints = RigidbodyConstraints.FreezePositionX;
            rigidbody.constraints = RigidbodyConstraints.FreezePositionZ;
            rigidbody.constraints = RigidbodyConstraints.FreezeRotation;
        }
    }
}
