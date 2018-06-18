using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WingOpenScript : MonoBehaviour {
    Animator WingAnim;
    combo Combo;
    bool wing1;
    bool wing2;
    float Timecount;
    public int Seekint;
    public GameObject WingControle;
    public GameObject Combocount;
	// Use this for initialization
	void Start () {
        WingAnim = WingControle.GetComponent<Animator>();
        Combo = Combocount.GetComponent<combo>();
	}
	
	// Update is called once per frame
	void Update () {

        if (Combo.ComboCount() > 10)
        {
           // WingAnim.SetInteger("Seekint", 1);
        }
	}
}
