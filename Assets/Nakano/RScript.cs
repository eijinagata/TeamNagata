using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RScript : MonoBehaviour
{

    public void ButtonPush()
    {
        //Debug.Log("LoadScene");
        SceneManager.LoadScene("GameScene");
    }

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}
}
