using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainScript : MonoBehaviour {

    //配列
    public GameObject[] Train;

	// Use this for initialization
	void Start () {
        //ランダムな数を代入
        int rdm = UnityEngine.Random.Range(0, 3);

        //確認用
       // Debug.Log(rdm);

        //配列のオブジェクトからrdm番目のオブジェクトを表示
        Instantiate(Train[rdm], transform.position, transform.rotation);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
