using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnObjectController : MonoBehaviour
{
    public GameObject enemy;    //生成するオブジェクト
    EnemyMove enemyMove;        //EnemyMove内のDATEアクセサーを使用したいから宣言

	// Use this for initialization
	void Start ()
    {
        //EnemyMoveを取得
        enemyMove = FindObjectOfType<EnemyMove>();	
	}
	
	// Update is called once per frame
	void Update ()
    {
        //フィールドから敵がいなくなったら１体スポーン
        if (enemyMove.DATE <= 0)
        {
            enemy.transform.position = transform.position;
            enemy.transform.forward = transform.forward;
            Instantiate(enemy);
        }
    }
}
