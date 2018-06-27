using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Rigidbody))]
public class Gamestart : MonoBehaviour
{
   // Animator animator;
    GameObject Name;
    Rigidbody rigidBody;

    public float Br = 1;
    float Ar = 1;
    public bool pointer = false;
    public bool o=false;
   // public Vector3 force = new Vector3(0, 10, 0);
 //   public ForceMode forceMode = ForceMode.VelocityChange;

    // Use this for initialization
    void Start()
    {
        rigidBody = gameObject.GetComponent<Rigidbody>();
        this.Name = GameObject.Find("Press");

     //   this.animator = GetComponent<Animator>();
    }

    public void Update()
    {
        this.Name.GetComponent<Text>().color = new Color(1, 1, Br, Ar);
        if (o == false)
        {
            if (pointer == true)
            {
                Br = Mathf.Clamp(Br - 0.05f, 0, 1);
            }
            else
            {
                Br = Mathf.Clamp(Br + 0.05f, 0, 1);
            }
        }
    } 
    public void OnUserAction()
    {
        Debug.Log("Click");
        //   this.animator.SetTrigger("Active");
        StartCoroutine ("Acti");
    }

    public void Hold()
    {
        pointer = true;
     //   this.animator.SetTrigger("on");
    }

    public void stay()
    {
        pointer = false;
     //   this.animator.SetTrigger("off");
    }

    private IEnumerator Acti()
    {
        o = true;
        for(int i = 0; i < 4; i++)
        {
            Br = 0;
            Ar = 0;
            yield return new WaitForSeconds(0.05f);
            Ar = 1;
            yield return new WaitForSeconds(0.05f);
            Debug.Log(i);
        }

        yield break;
    }
}

