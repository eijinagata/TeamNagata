using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pauseController : MonoBehaviour {

    int clickFlag = 1;
    bool pauseFlag = false;

    public bool PAUSE
    {
        get { return pauseFlag; }
    }

    // Use this for initialization
    void Start ()
    {
        clickFlag = 1;
        pauseFlag = false;
    }
	
	// Update is called once per frame
	void Update ()
    {
        switch (clickFlag)
        {
            case 1:
                pauseFlag = false;
                break;
            case -1:
                pauseFlag = true;
                break;
            default:
                break;
        }
	}

    public void ButtonClick()
    {
        clickFlag = clickFlag * -1;
    }
}
