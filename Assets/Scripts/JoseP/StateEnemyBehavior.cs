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
		target = other.transform;
		currentState.ToChaseState();
	}

	public void SightExit(Collider2D other) {
		currentState.ToPatrolState();
	}

<<<<<<< HEAD
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
=======
	private void OnTriggerEnter2D(Collider2D coll)
	{
		if (coll.tag == "vomit")
		{
			Debug.Log("TRIGGERED");
			/*enemy.moveSpeed = 0;
            stopping = true;
            time = 0.0f;*/
			moveSpeed = 0;
			//new WaitForSecondsVomit();
			//moveSpeed = 4;
			//StartCoroutine(TimeLapse());
			/* Vector3 velocity;
                if (!this.rigidbody2D.isSleeping){
                    this.rigidbody.sleep();
                    this.velocity = this.rigidbody.velocity;
                } else {
                    this.rigidbody.WakeUp();
                    this.rigidbody.velocity = this.velocity;
                }*/
		}
	}
>>>>>>> a8f1a5bf6eac4acc03c23fb766740b2a75af9274
}