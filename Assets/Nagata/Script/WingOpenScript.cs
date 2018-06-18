using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WingOpenScript : MonoBehaviour {
    Animation WingAnim;
    combo Combo;
    bool wing1;
    bool wing2;
    float Timecount;
    public GameObject WingControle;
    public GameObject Combocount;
	// Use this for initialization
	void Start () {
        WingAnim = WingControle.GetComponent<Animation>();
        Combo = Combocount.GetComponent<combo>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Combo.ComboCount() >= 10)
        {
            wing1 = true;
            if (wing1 == true)
            {
                WingAnim.Play("WingOpen1");
                Timecount += Time.deltaTime;
            }
            if (Timecount <= 0.3)
            {
                WingAnim.Play("WingOpen2");
            }
        }
	}
}
