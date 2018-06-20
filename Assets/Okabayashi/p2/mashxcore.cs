using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mashxcore : MonoBehaviour {

    combo Combo;
    GameObject Dir;
    void Start () {
        Dir = GameObject.Find("Director");
        Combo = Dir.GetComponent<combo>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
