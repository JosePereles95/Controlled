using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[RequireComponent(typeof(NpcMovement))]
public class StateEnemyBehavior : MonoBehaviour {
	
	public Transform[] wayPoints;
	[HideInInspector] public Vector3 posPlayer;
	[HideInInspector] public Transform target;
	[HideInInspector] public int moveSpeed = 4;

	[HideInInspector] public IEnemyState currentState;
	[HideInInspector] public PatrolState patrolState;
	[HideInInspector] public ChaseState chaseState;
    [HideInInspector] public ControlledState controlledState;

    public static StateEnemyBehavior Instance;

    private NpcMovement theController;

	void Awake(){
        theController = GetComponent<NpcMovement>();

		patrolState = new PatrolState (this, theController);
		chaseState = new ChaseState (this, theController);
        controlledState = new ControlledState(this, theController);
	}

	void Start (){
		currentState = patrolState;
	}

	void Update (){
		currentState.UpdateState ();
		posPlayer = this.transform.position;
	}

	public void SightTriggered(Collider2D other) {
		if (other.tag == "Player") {
			target = other.transform;
			currentState.ToChaseState();
		}
	}

	public void SightExit(Collider2D other) {
		if (other.tag == "Player") {;
			currentState.ToPatrolState();
		}
	}

    public void EnterControlZone(Collider2D other)
    {
        if(other.tag == "Player")
        {
            other.GetComponent<PlayerInput>().ToCanControl(theController);
        }
    }

    public void ControlZoneStay(Collider2D other)
    {
        if(other.tag == "Player")
        {
            if(Input.GetKeyDown(KeyCode.E))
            {
                other.GetComponent<PlayerInput>().Parasitar();
                currentState.ToControlledState();
            }
        }
    }

    public void ExitControlZone(Collider2D other)
    {
        if(other.tag == "Player")
        {
            other.GetComponent<PlayerInput>().ExitControlZone();
        }
    }
}