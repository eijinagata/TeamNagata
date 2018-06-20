using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Derete : MonoBehaviour {

    GameObject record;

    private void Start()
    {
        record = GameObject.Find("Hith");
    }
 
   public void DErete()
    {

        PlayerPrefs.DeleteAll();
        record.GetComponent<record>().highScoreText.text = "HighScore: 0";
    }
}
