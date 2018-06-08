using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DebugUISistem : MonoBehaviour {

    public Text HeatLevelText;
    public  GameObject unit;
    UnitLotate heatlevel;
	// Use this for initialization
	void Start () {
       
        heatlevel = unit.GetComponent<UnitLotate>();
	}
	
	// Update is called once per frame
	void Update () {
        HeatLevelText.text = string.Format("Heat:{0:0000}", heatlevel.GetHeatLevel());
    }
}
