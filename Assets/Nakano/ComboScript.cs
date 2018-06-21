using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ComboScript : MonoBehaviour {

    int combo = 50;
    public Text Combolabel;
    int count = 0;
    bool swich = false;
    float totalTime;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (combo > count)
        {
            totalTime += Time.deltaTime * 45;
            count = (int)totalTime;
            Combolabel.text = count.ToString();
        }
    }
}
