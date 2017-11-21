using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class particleSystemController : MonoBehaviour {
    private ParticleSystem pS;
    private Animator anim;
    
	// Use this for initialization
	void Start () {
        pS = GetComponent<ParticleSystem>();
        anim = GetComponentInParent<Animator>();
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
