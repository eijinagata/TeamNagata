using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour {

    Quaternion Lote1 = Quaternion.Euler(0, 90, 0);

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        transform.rotation = Quaternion.Euler(0, 90, 0);	
	}
}
