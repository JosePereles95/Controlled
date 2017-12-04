using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[RequireComponent(typeof(NpcMovement))]
public class StateEnemyBehavior : MonoBehaviour {
	
	public Transform[] wayPoints;
	[HideInInspector] public Vector3 posPlayer;
	[HideInInspector] public Transform target;
	[HideInInspector] public int moveSpeed = 4;
	[HideInInspector] public bool parasitado = false;
	[HideInInspector] public bool muerto = false;
	[HideInInspector] public bool canPatrol = true;
	[HideInInspector] public bool parado = false;

	[HideInInspector] public IEnemyState currentState;
	[HideInInspector] public PatrolState patrolState;
	[HideInInspector] public ChaseState chaseState;
    [HideInInspector] public ControlledState controlledState;
	[HideInInspector] public DiedState diedState;

    //Life management
    private TankHealth healthBar;
    public float startingLife = 100f;

    public static StateEnemyBehavior Instance;

    private NpcMovement theController;

	void Awake(){
        theController = GetComponent<NpcMovement>();
		parado = false;
		patrolState = new PatrolState (this, theController);
		chaseState = new ChaseState (this, theController);
        controlledState = new ControlledState(this, theController);
		diedState = new DiedState(this, theController);

        //Life initialitation
        healthBar = GetComponent<TankHealth>();
        healthBar.m_StartingHealth = startingLife;
        healthBar.DisableHealthBar();
	}

	void Start (){
		currentState = patrolState;
	}

	void Update (){
		currentState.UpdateState ();
		Debug.Log (this.name + " -- " + currentState);
		posPlayer = this.transform.position;
	}

	public void SightTriggered(Collider2D other) {
		if (!parasitado && !muerto) {
			target = other.transform;
			currentState.ToChaseState ();
		}
	}

    public void TakeDamage(float damage)
    {
        if (healthBar.TakeDamage(damage))
        {
            currentState.ToDiedState();
            healthBar.DisableHealthBar();
        }
    }

	public void SightExit(Collider2D other) {
		if (canPatrol)
			currentState.ToPatrolState();
	}

    public void EnterControlZone(Collider2D other)
    {
		if(other.tag == "Player" && !muerto)
        {
            other.GetComponent<PlayerInput>().ToCanControl(theController);
        }
    }

    public void ControlZoneStay(Collider2D other)
    {
		if(other.tag == "Player" && !muerto)
        {
            if(Input.GetKeyDown(KeyCode.E))
            {
                //Debug.Log ("Controlado");
                controlledState.parasite = other.GetComponent<PlayerInput>();
                controlledState.parasite.Parasitar();
                canPatrol = false;
				StartCoroutine (WaitForParasitar ());
                currentState.ToControlledState();
            }
        }
    }

    public void ExitControlZone(Collider2D other)
    {
		if(other.tag == "Player" && !muerto)
        {
            other.GetComponent<PlayerInput>().ExitControlZone();
        }
    }

	private IEnumerator WaitForParasitar(){
		yield return new WaitForSeconds(1.3f);
		parasitado = true;
        healthBar.EnableHealthBar(); //Enseñar barra de vida cuando acaba el parasitamiento
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.tag == "vomit" && !parado && currentState != controlledState) {
            this.GetComponent<NpcMovement>().SetSpeed(0);
			parado = true;
			StartCoroutine (WaitForVomit ());
		}
	}

	private IEnumerator WaitForVomit(){
		yield return new WaitForSeconds(4f);
		parado = false;
        this.GetComponent<NpcMovement>().SetSpeed(4);
	}
}