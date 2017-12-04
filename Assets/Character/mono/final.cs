using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class final : MonoBehaviour {

	public GameObject cartelFIN;

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.tag == "Player")
		{
			cartelFIN.gameObject.SetActive (true);
		}
	}
}
