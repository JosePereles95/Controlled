using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class particleSystemController : MonoBehaviour {
    private ParticleSystem pS;
    private Animator anim;
    public Material newMat;
	// Use this for initialization
	void Start () {
        pS = GetComponent<ParticleSystem>();
        anim = GetComponentInParent<Animator>();
        pS.GetComponent< ParticleSystemRenderer > ().material = newMat;

    }

	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.V)) { 
			Debug.Log(anim.name);
            if (pS.isEmitting)
            {
                pS.Stop();
                anim.Play("Idle");
                Debug.Log("Stopping particle system");
            }
            else {
                pS.Play();
                anim.Play("Vomit");
                Debug.Log("Playing particle system");
            }
        }
	}
}
