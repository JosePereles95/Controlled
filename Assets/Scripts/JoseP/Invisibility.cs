using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Invisibility : MonoBehaviour {

	public int duration = 2;
	public SkinnedMeshRenderer[] listSprites;

	private float minimum = 0f;
	private float maximum = 1f;

	private float time = 0.0f;
	private float timeVisibility = 0.0f;

	private bool invisible = false;
	private bool moving = false;

	void Update () {
		time += Time.deltaTime;
		timeVisibility += Time.deltaTime;
		//Debug.Log (time);

		if (Input.anyKeyDown) {
			moving = true;
			time = 0.0f;

		}

		if (time > 2f && !invisible) {
			timeVisibility = 0.0f;
			invisible = true;
			moving = false;
			this.GetComponentInChildren<SpriteRenderer> ().enabled = true;

		}

		if (invisible && moving) {
			timeVisibility = 0.0f;
			invisible = false;
			this.GetComponentInChildren<SpriteRenderer> ().enabled = false;
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

		this.GetComponentInChildren<SpriteRenderer> ().color = new Color (1f, 1f, 1f, Mathf.SmoothStep (minimum, maximum, timeVisibility/duration));
	}

	void GoInvisible (){
		Debug.Log ("Invisible");
		for (int i = 0; i < listSprites.Length; i++) {
			listSprites [i].GetComponent<SkinnedMeshRenderer>().enabled = false;
		}

		this.GetComponentInChildren<SpriteRenderer> ().color = new Color (1f, 1f, 1f, Mathf.SmoothStep (maximum, minimum, timeVisibility/duration));
	}
}