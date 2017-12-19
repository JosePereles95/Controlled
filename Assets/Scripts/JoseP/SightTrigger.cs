using UnityEngine;
using System.Collections;

public class SightTrigger : MonoBehaviour {
	public SightAlert theSignal;

	void OnTriggerStay2D(Collider2D other) {
		if (other.tag == "Player")
		{
			gameObject.GetComponentInParent<StateEnemyBehavior>().SightTriggered(other);
			theSignal.ActivateAlert();
		}
	}

	void OnTriggerExit2D(Collider2D other) {
		if (other.tag == "Player")
		{
			gameObject.GetComponentInParent<StateEnemyBehavior>().SightExit(other);
			theSignal.ActivaLost();
		}
	}
}