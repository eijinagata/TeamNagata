using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class rankingmanager : MonoBehaviour {
    int newscore = 0;
    int rankscore1=1000;
    int rankscore2=800;
    int rankscore3=500;
    public Text rank1text;
    public Text rank2text;
    public Text rank3text;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        rank1text.text = rankscore1.ToString();
        rank2text.text = rankscore2.ToString();
        rank3text.text = rankscore3.ToString();

    }
}
