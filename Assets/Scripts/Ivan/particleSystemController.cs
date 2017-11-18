using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class particleSystemController : MonoBehaviour {
    private ParticleSystem pS;
    
	// Use this for initialization
	void Start () {
        pS = GetComponent<ParticleSystem>();
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown("v")) {
            if (pS.isEmitting)
            {
                pS.Stop();
                Debug.Log("Stopping particle system");
            }
            else {
                pS.Play();
                Debug.Log("Playing particle system");
            }
        }
	}
}
