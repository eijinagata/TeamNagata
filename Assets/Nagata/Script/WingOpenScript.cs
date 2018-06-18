using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WingOpenScript : MonoBehaviour {
    Animator WingAnim;
    ParticleSystem BunerPurticle;
    combo Combo;
    bool wing1;
    bool wing2;
    float Timecount;
    public int Seekint;
    public GameObject WingControle;
    public GameObject Combocount;
    public ParticleSystem[] Particles=new ParticleSystem[3];
	// Use this for initialization
	void Start () {
        WingAnim = WingControle.GetComponent<Animator>();
        BunerPurticle = WingControle.GetComponent<ParticleSystem>();
        Combo = Combocount.GetComponent<combo>();
       /* Particles[1] = Particles[1].GetComponent<ParticleSystem>();
        Particles[2] = Particles[2].GetComponent<ParticleSystem>();
        Particles[3] = Particles[3].GetComponent<ParticleSystem>();*/
    }
	
	// Update is called once per frame
	void Update () {

        if (Combo.GetCombocount() >= 10)
        {
            Timecount += Time.deltaTime;
            WingAnim.SetInteger("Seekint", 1);
           
            if (Timecount >= 1.6f)
            {
                Particles[0].Play();
                Particles[1].Play();
                Particles[2].Play();
            }
        }
	}
}
