using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AccellScript : MonoBehaviour {
    Move3 AccellSphia;
    GameObject gameobj;
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Ball")
        {
            gameobj = other.gameObject;
            AccellSphia = gameobj.GetComponent<Move3>();
            
            AccellSphia.PlusSpeed(0.3f);
        }
    }
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	}
}
