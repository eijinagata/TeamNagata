using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LtypeUnitLotateScript : MonoBehaviour {
    Animator LUanimator;
    Vector3 pos;
    public static float Unitlotatespeed=0.01f;
    Vector3 PelsonaPos;
    bool IsUp = false;
    bool IsOneshot = false;
    float FirstAgree = 180;
    float lotetyme = 0;
    float Timecount = 0.4f;
    float Uptime;
    int flagint;
    Quaternion Lote;
    Quaternion Lote1 = Quaternion.Euler(0, 90, 0);
    Quaternion Lote2 = Quaternion.Euler(0, 180, 0);
    Quaternion Lote3 = Quaternion.Euler(0, 270, 0);
    Quaternion Lote4 = Quaternion.Euler(0, 360, 0);
    Vector3 UpPos;
    bool loteteflag1 = false;//アニメーション１が起動されるとtrueになる処理。
    bool loteteflag2 = false;//アニメーション2が起動されるとtrueになる処理。
    bool loteteflag3 = false;//アニメーション3が起動されるとtrueになる処理。
    bool loteteflag4 = false;//アニメーション4が起動されるとtrueになる処理。
    bool SUAccessflag;//マウスがLtypeUnitの位置に接触している場合。
    bool islotateflag = false;
    Animation SUanim;

    public bool GetIslotatetypeL()//回転中かどうかわかるフラグのGetインデクサ
    {
        return islotateflag;
    }
    // Use this for initialization
    public void FlagSwitch1()
    {
        loteteflag1 = true;
    }
    IEnumerator Loteteflag1Diley()//左クリックが押された１秒後にloteteflag1がtrueになる処理
    {

        yield return new WaitForSeconds(Unitlotatespeed);  //10秒待つ

        loteteflag1 = true;

    }
    IEnumerator Loteteflag2Diley()//左クリックが押された１秒後にloteteflag2がtrueになる処理
    {
        yield return new WaitForSeconds(LtypeUnitLotateScript.Unitlotatespeed);  //10秒待つ
        loteteflag2 = true;

    }
    IEnumerator Loteteflag3Diley()//左クリックが押された１秒後にloteteflag3がtrueになる処理
    {
        yield return new WaitForSeconds(LtypeUnitLotateScript.Unitlotatespeed);  //10秒待つ
        loteteflag3 = true;

    }
    IEnumerator Loteteflag4Diley()//左クリックが押された１秒後にloteteflag4がtrueになる処理
    {
        yield return new WaitForSeconds(LtypeUnitLotateScript.Unitlotatespeed);  //10秒待つ
        loteteflag1 = false;
        loteteflag2 = false;
        loteteflag3 = false;
        loteteflag4 = false;

    }


    void Start()
    {
        UpPos = new Vector3(transform.position.x, transform.position.y * 2.1f, transform.position.z);
        PelsonaPos = transform.position;
    }
    public void Lote1Contlole()
    {
        if (IsOneshot == false)
        {
            islotateflag = true;
        }
        if (lotetyme < Timecount && islotateflag == true)
        {
            // Lote = Quaternion.Euler(transform.rotation.y, transform.rotation.y+90, transform.rotation.z);
            lotetyme += Time.deltaTime;
            transform.rotation = Quaternion.Slerp(transform.rotation, Lote1, lotetyme);

            if (lotetyme > Timecount)
            {
                lotetyme = 0;
                if (IsOneshot == false)
                {
                    islotateflag = false;
                    IsOneshot = true;
                }

            }


        }
    }

    public void Lote2Contlole()
    {
        if (IsOneshot == true)
        {
            islotateflag = true;
        }
        if (lotetyme < Timecount && islotateflag == true)
        {
            // Lote = Quaternion.Euler(transform.rotation.y, transform.rotation.y *180, transform.rotation.z);
            lotetyme += Time.deltaTime;
            transform.rotation = Quaternion.Slerp(transform.rotation, Lote2, lotetyme);
            if (lotetyme < Uptime && islotateflag == true)
            {
                transform.position = Vector3.Lerp(transform.position, UpPos, Uptime);
            }
            if (lotetyme > Uptime && islotateflag == true)
            {
                transform.position = Vector3.Lerp(transform.position, PelsonaPos, Uptime);
                // islotateflag = false;
            }

            if (lotetyme > Timecount)
            {
                lotetyme = 0;
                if (IsOneshot == true)
                {
                    islotateflag = false;
                    IsOneshot = false;
                }

            }


        }
    }

    public void Lote3Contlole()
    {
        if (IsOneshot == false)
        {
            islotateflag = true;
        }
        if (lotetyme < Timecount && islotateflag == true)
        {
            //Lote = Quaternion.Euler(transform.rotation.y, transform.rotation.y * 270, transform.rotation.z);
            lotetyme += Time.deltaTime;
            transform.rotation = Quaternion.Slerp(transform.rotation, Lote3, lotetyme);
            if (lotetyme < Uptime && islotateflag == true)
            {
                transform.position = Vector3.Lerp(transform.position, UpPos, Uptime);
            }
            if (lotetyme > Uptime && islotateflag == true)
            {
                transform.position = Vector3.Lerp(transform.position, PelsonaPos, Uptime);
                // islotateflag = false;
            }

            if (lotetyme > Timecount)
            {
                lotetyme = 0;
                if (IsOneshot == false)
                {
                    islotateflag = false;
                    IsOneshot = true;
                }

            }


        }
    }

    public void Lote4Contlole()
    {
        if (IsOneshot == true)
        {
            islotateflag = true;
        }
        if (lotetyme < Timecount && islotateflag == true)
        {
            //Lote = Quaternion.Euler(transform.rotation.y, transform.rotation.y * 360, transform.rotation.z);
            lotetyme += Time.deltaTime;
            transform.rotation = Quaternion.Slerp(transform.rotation, Lote4, lotetyme);
            if (lotetyme < Uptime && islotateflag == true)
            {
                transform.position = Vector3.Lerp(transform.position, UpPos, Uptime);
            }
            if (lotetyme > Uptime && islotateflag == true)
            {
                transform.position = Vector3.Lerp(transform.position, PelsonaPos, Uptime);
                // islotateflag = false;
            }

            if (lotetyme > Timecount)
            {
                lotetyme = 0;
                if (IsOneshot == true)
                {
                    islotateflag = false;
                    IsOneshot = false;
                    flagint = 0;
                }
            }


        }

    }

    // Update is called once per frame
    void Update()
    {

        Debug.Log(loteteflag1);
        switch (flagint)
        {
            case 1:
                Lote1Contlole();
                break;
            case 2:
                Lote2Contlole();
                break;
            case 3:
                Lote3Contlole();
                break;
            case 4:
                Lote4Contlole();
                break;
        }

        if (Input.GetMouseButtonDown(0) && SUAccessflag == true)//一本道のコライダーにマウスがいるとき、マウスの左クリックが押された場合
        {

            if (flagint == 0 && islotateflag == false && loteteflag1 == false)
            {
                flagint = 1;
                StartCoroutine("Loteteflag1Diley");
                Debug.Log("1起動");
            }
            if (flagint == 1 && islotateflag == false && loteteflag1 == true && loteteflag2 == false)
            {
                flagint = 2;
                StartCoroutine("Loteteflag2Diley");
                Debug.Log("2起動");
            }
            if (flagint == 2 && islotateflag == false && loteteflag1 == true && loteteflag2 == true && loteteflag3 == false)
            {
                flagint = 3;
                StartCoroutine("Loteteflag3Diley");
                Debug.Log("３起動");
            }
            if (flagint == 3 && islotateflag == false && loteteflag1 == true && loteteflag2 == true && loteteflag3 == true && loteteflag4 == false)
            {
                flagint = 4;
                StartCoroutine("Loteteflag4Diley");
                Debug.Log("4起動");

            }

        }
    }
    public void AccessLU()//マウスが一本道のコライダーに入った時
    {
        SUAccessflag = true;
    }
    public void EscapeLU()//マウスが一本道のコライダーより離れたとき
    {
        SUAccessflag = false;
    }
}
