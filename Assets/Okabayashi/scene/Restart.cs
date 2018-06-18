using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Restart : MonoBehaviour {
    int score;

  /*  private void Start()
    {
        score = TheCount.Total();
    }*/
    public void REstart()
    {

        SceneManager.LoadScene("gamescene");

    }
}
