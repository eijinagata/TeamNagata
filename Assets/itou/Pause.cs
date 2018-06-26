using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    [SerializeField]
    //　ポーズした時に表示するUI
    //private GameObject pauseUI;
    //　ポーズUIのインスタンス
    //private GameObject instancePauseUI;

    public GameObject image;

    bool moveFlag;

    public bool FLAG
    {
        get { return moveFlag; }
    }

    void Start()
    {
        moveFlag = false;
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKeyDown("q"))
        //{
        //    if (instancePauseUI == null)
        //    {
        //        instancePauseUI = GameObject.Instantiate(pauseUI) as GameObject;
        //        Time.timeScale = 0f;
        //    }
        //    else
        //    {
        //        Destroy(instancePauseUI);
        //        Time.timeScale = 1f;
        //    }
        //}
    }

    public void Click()
    {
        if (image.activeSelf == false)
        {
            moveFlag = true;
            image.SetActive(true);
            //instancePauseUI = GameObject.Instantiate(image) as GameObject;
            Time.timeScale = 0f;
        }
        else
        {
            moveFlag = false;
            image.SetActive(false);
            //Destroy(instancePauseUI);
            Time.timeScale = 1f;
        }
    }
}