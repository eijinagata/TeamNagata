using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Gameset : MonoBehaviour {

    public void Finish()
    {
        SceneManager.LoadScene("result");
    }
}
