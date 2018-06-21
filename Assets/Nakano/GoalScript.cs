using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalScript : MonoBehaviour
{
    

	// Use this for initialization
	void Start () {
        int rdmz = UnityEngine.Random.Range(0, 4);
        //Debug.Log(rdmz);
        Vector3 pos = transform.position;
        int rdmx;
        rdmx = UnityEngine.Random.Range(-1, 3);
        //Debug.Log(rdmx);
        if(rdmx==-1)
        {
            pos.x = rdmx;
            pos.z = rdmz;
            transform.position = pos;
        }
        else
        {
            pos.z = 3;
            pos.x = rdmx;
            transform.position = pos;
        }
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.B))
        {
            Vector3 pos = transform.position;

            int rdmz = UnityEngine.Random.Range(0, 4);
            //float oldnumberZ = rdmz;

            int rdmx = UnityEngine.Random.Range(-1, 3);
            //float oldnumberX = rdmx;

            if (rdmx == -1)
            {
                pos.x = rdmx;
                pos.z = rdmz;
                transform.position = pos;
            }
            else
            {
                pos.z = 3;
                pos.x = rdmx;
                transform.position = pos;
            }
        }
	}
}
