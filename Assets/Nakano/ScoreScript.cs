using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour
{
    //絶対に使用しないように
    public bool MaxS = false;

    int score = 100;
    public Text Scorelabel;
    int count = 0;
    float totalTime;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(score>count)
        {
            totalTime += Time.deltaTime * 90;
            count = (int)totalTime;
            Scorelabel.text = count.ToString();

            if(score<count)
            {
                Scorelabel.text = score.ToString();
                MaxS = true;
            }
            if(score==count)
            {
                MaxS = true;
            }
        }
    }
}
