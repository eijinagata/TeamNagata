using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitLotate : MonoBehaviour {

    public float time;

    Quaternion a = Quaternion.AngleAxis(0, Vector3.up);
    Quaternion b = Quaternion.AngleAxis(90, Vector3.up);

    float kakudo = 0f;
    float degStart = 0f;
    float degEnd = 90f;
    float RotlLimit = 90f;

    bool startRot = false;

    public void RotateCom()
    {
        if (Input.GetMouseButtonDown(0) && !startRot)
        {
            startRot = true;
        }

        if (startRot)
        {
            time += Time.deltaTime;
            kakudo = Mathf.Lerp(degStart, degEnd, time * 5f);
            transform.rotation = Quaternion.AngleAxis(kakudo, Vector3.up);
            if (kakudo >= RotlLimit)
            {
                startRot = false;
                time = 0;
                degStart += 90;
                degEnd += 90;
                RotlLimit += 90;
            }
        }
    }
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        RotateCom();
	}
}
