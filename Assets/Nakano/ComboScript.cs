using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ComboScript : MonoBehaviour
{
    //絶対に使用しないように
    public bool MaxC = false;
    int combo = 0;
    public Text Combolabel;
    int count = 0;
    float totalTime;
    bool swich = true;
    // Use this for initialization
    void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Combolabel.text = combo.ToString();
            MaxC = true;
            swich = false;
        }
        if(combo==0)
        {
            Combolabel.text = combo.ToString();
            MaxC = true;
            swich = false;
        }
        if(swich==true)
        {

            if (combo > count)
            {
                totalTime += Time.deltaTime * 45;
                count = (int)totalTime;
                Combolabel.text = count.ToString();

                if (combo < count)
                {
                    Combolabel.text = combo.ToString();
                    MaxC = true;
                }

                if (combo == count)
                {
                    MaxC = true;
                }

            }
        }
    }
}
