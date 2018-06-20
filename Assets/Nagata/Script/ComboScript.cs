using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComboScript : MonoBehaviour {

    public GameObject Combocount;
    public GameObject ComboUi;
    Animator ComboAnim;
    combo Combo;
    public void ComboUI()
    {
        if (Combo.GetCombocount()>=5)
        {
            ComboAnim.SetInteger("ComboInt", 1);
        }
        if (Combo.GetCombocount() == 0)
        {
            ComboAnim.SetInteger("ComboInt", 2);
        }
    }
	// Use this for initialization
	void Start () {
        Combo = Combocount.GetComponent<combo>();
        ComboAnim = ComboUi.GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {
        ComboUI();
	}
}
