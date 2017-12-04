using UnityEngine;
using System.Collections;

public class SightTrigger : MonoBehaviour {

	void OnTriggerStay2D(Collider2D other) {
		if (other.tag == "Player")
			gameObject.GetComponentInParent<StateEnemyBehavior> ().SightTriggered (other);
	}

	void OnTriggerExit2D(Collider2D other) {
		if (other.tag == "Player")
			gameObject.GetComponentInParent<StateEnemyBehavior> ().SightExit (other);
	}
}