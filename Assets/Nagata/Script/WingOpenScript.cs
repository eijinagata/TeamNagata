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
    bool SeekFlag = false;
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

    public void Seekence()
    {
        if (Combo.GetCombocount() >= 10)//コンボカウントが１０以上になった場合
        {
            Timecount += Time.deltaTime;
            WingAnim.SetBool("OpenFlag", true);

            if (Timecount >= 1.6f)
            {
                Particles[0].Play();
                Particles[1].Play();
                Particles[2].Play();
            }
        }
        if (Combo.GetCombocount() == 0)//コンボカウントが０に戻った場合
        {
            Particles[0].startColor = Color.blue;
            Particles[1].startColor = Color.blue;
            Particles[2].startColor = Color.blue;
            WingAnim.SetBool("OpenFlag", false);
            Timecount = 0;
            Particles[0].Stop();
            Particles[1].Stop();
            Particles[2].Stop();
        }
        if (Combo.GetCombocount() >= 30)//コンボカウントが３０以上になった場合
        {
            Timecount += Time.deltaTime;
            Particles[0].startColor = Color.red;
            Particles[1].startColor = Color.red;
            Particles[2].startColor = Color.red;

        }
    }
	// Update is called once per frame
	void Update () {
        Seekence();
        

	}
}
