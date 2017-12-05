using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Invisibility : MonoBehaviour {


    AudioSource fuenteAudio;

    public int durationFade;
	public SkinnedMeshRenderer[] listSprites;
	public float waitTime;
	public float vomitTime;

	private float minimum = 0f;
	private float maximum = 1f;

	private float time = 0.0f;
	private float timeVisibility = 0.0f;

	private bool invisible = false;
	private bool moving = false;
	private bool vomiting = false;
	private GameObject vomito;
    public AudioClip sonidoinvisible;
 

    void Start(){
        fuenteAudio = GetComponent<AudioSource>();
        vomito = GameObject.FindGameObjectWithTag ("vomit");
	}

	void Update () {
		time += Time.deltaTime;
		timeVisibility += Time.deltaTime;
		//Debug.Log (time);

		if (Input.anyKeyDown || Input.anyKey) {
			moving = true;
			time = 0.0f;
		}

		if (time > waitTime && !invisible) {
			timeVisibility = 0.0f;
			invisible = true;
			moving = false;
			this.GetComponentInChildren<SpriteRenderer> ().enabled = true;
		}
		//Debug.Log ("time: " + time + " ;  vomitTime: " + vomitTime);
		if (time > vomitTime) {
			if (invisible) {
				vomiting = true;
				moving = true;
				vomito.GetComponent<vomitController> ().Vomit ();
			}
		}

		if ((invisible && moving) || vomiting) {
			timeVisibility = 0.0f;
			invisible = false;
			this.GetComponentInChildren<SpriteRenderer> ().enabled = false;
			vomiting = false;
			time = 0.0f;
		}

		if (invisible)
            GoInvisible();
		else if(moving)
			GoVisible();
	}

	void GoVisible (){
		for (int i = 0; i < listSprites.Length; i++) {
			listSprites [i].GetComponent<SkinnedMeshRenderer>().enabled = true;
		}

		this.GetComponentInChildren<SpriteRenderer> ().color = new Color (1f, 1f, 1f, Mathf.SmoothStep (minimum, maximum, timeVisibility/1));
	}

	void GoInvisible (){
		for (int i = 0; i < listSprites.Length; i++) {
			listSprites [i].GetComponent<SkinnedMeshRenderer>().enabled = false;

        }
 

        this.GetComponentInChildren<SpriteRenderer> ().color = new Color (1f, 1f, 1f, Mathf.SmoothStep (maximum, minimum, timeVisibility/durationFade));
    }
}