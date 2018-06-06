using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class combo : MonoBehaviour {


    GameObject limit;
    GameObject combotext;
    int count = 0;
//   public int combopoint = 100;//コンボ加算点数
    float time;
	// Use this for initialization
	void Start () {
        limit = GameObject.Find("Timelimit");
        combotext = GameObject.Find("Combo");
    }
	
	// Update is called once per frame
	void Update () {
        time += Time.deltaTime;
        if (time >= 5)
        {
            count = 0;
        }

        limit.GetComponent<Text>().text=time.ToString();
        combotext.GetComponent<Text>().text = count.ToString();
    }

    public void active()
    {
        ComboCount();
    }


   public int ComboCount() //
    {
        time = 0;
        count += 1;
        return count;
    }
}
