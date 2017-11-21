using UnityEngine;
using System.Collections;

public class SightTrigger : MonoBehaviour {

	void OnTriggerStay2D(Collider2D other) {
		gameObject.GetComponentInParent<StateEnemyBehavior> ().SightTriggered (other);
	}

	void OnTriggerExit2D(Collider2D other) {
		gameObject.GetComponentInParent<StateEnemyBehavior> ().SightExit (other);
	}
}