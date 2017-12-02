using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlledZone : MonoBehaviour {

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GetComponentInParent<StateEnemyBehavior>().EnterControlZone(collision);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        GetComponentInParent<StateEnemyBehavior>().ControlZoneStay(collision);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        GetComponentInParent<StateEnemyBehavior>().ExitControlZone(collision);
    }
}
