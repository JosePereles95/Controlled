using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Invisibility : MonoBehaviour {

	public int duration = 1;

	private float minimum = 0.0f;
	private float maximum = 1f;

	private float time = 0.0f;
	private float timeVisibility = 0.0f;

	private bool invisible = false;
	private bool moving = false;

	void Update () {
		time += Time.deltaTime;
		timeVisibility += Time.deltaTime;
		Debug.Log (time);

		if (Input.anyKeyDown) {
			moving = true;
			time = 0.0f;
		}

		if (time > 2f && !invisible) {
			timeVisibility = 0.0f;
			invisible = true;
			moving = false;
		}

		if (invisible && moving) {
			timeVisibility = 0.0f;
			invisible = false;
		}

		if (invisible)
			GoInvisible();
		else if(moving)
			GoVisible();
	}

	void GoVisible (){
		this.GetComponent<SpriteRenderer> ().color = new Color (1f, 1f, 1f, Mathf.SmoothStep (minimum, maximum, timeVisibility/duration));
	}

	void GoInvisible (){
		this.GetComponent<SpriteRenderer> ().color = new Color (1f, 1f, 1f, Mathf.SmoothStep (maximum, minimum, timeVisibility/1));
	}
}