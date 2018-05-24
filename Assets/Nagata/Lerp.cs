using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lerp : MonoBehaviour
{

    public float time;

    Quaternion a = Quaternion.AngleAxis(0, Vector3.up);
    Quaternion b = Quaternion.AngleAxis(90, Vector3.up);

    float kakudo = 0f;
    float degStart = 0f;
    float degEnd = 90f;

    bool startRot = false;


    // Use this for initialization
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {
        
        //transform.rotation = Quaternion.AngleAxis(time*10.0f, Vector3.up);
        /*
        Quaternion q = Quaternion.Lerp(a, b, time * 0.1f);
        if (transform.rotation.y<=90f)
        {
            transform.Rotate(q.eulerAngles);

        }
        */

        if (Input.GetMouseButtonDown(0)&&!startRot)
        {
            startRot = true;
        }

        if (startRot)
        {
            time += Time.deltaTime;
            kakudo = Mathf.Lerp(degStart, degEnd, time * 0.1f);
            transform.rotation = Quaternion.AngleAxis(kakudo, Vector3.up);
            if (kakudo>=90)
            {
                startRot = false;
                time = 0;
                degStart += 90;
                degEnd += 89;
            }
        }
    }
}
