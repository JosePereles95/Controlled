using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[RequireComponent(typeof(NpcMovement))]
public class StateEnemyBehavior : MonoBehaviour {

	public Transform[] wayPoints;
	[HideInInspector] public Vector3 posPlayer;
	[HideInInspector] public Transform target;
	[HideInInspector] public int moveSpeed;
	[HideInInspector] public bool parasitado = false;
	[HideInInspector] public bool muerto = false;
	[HideInInspector] public bool canPatrol = true;
	[HideInInspector] public bool parado = false;

	[HideInInspector] public IEnemyState currentState;
	[HideInInspector] public PatrolState patrolState;
	[HideInInspector] public ChaseState chaseState;
	[HideInInspector] public ControlledState controlledState;
	[HideInInspector] public DiedState diedState;

	private float aux;

	public static StateEnemyBehavior Instance;

	//Life magement
	public float vidaInicial = 100f;
	private TankHealth lifeBar;

	private NpcMovement theController;

	//Spawn management
	public SpawnPoint spawnPoint;

	void Awake(){
		InitCharacter();
	}

	public void OnEnable()
	{
		InitCharacter();
	}

	public void InitCharacter()
	{
		theController = GetComponent<NpcMovement>();
		parado = false;
		patrolState = new PatrolState(this, theController);
		chaseState = new ChaseState(this, theController);
		controlledState = new ControlledState(this, theController);
		diedState = new DiedState(this, theController);

		//Life Initialitation
		lifeBar = GetComponent<TankHealth>();
		if (lifeBar != null) {
			lifeBar.m_StartingHealth = vidaInicial;
			lifeBar.DisableHealthBar ();
		}

		//Bool init
		parasitado = false;
		muerto = false;
		canPatrol = true;

		if(theController.anim != null)
        {
            theController.anim.SetBool("isDead", false);
            theController.anim.Play("Iddle");
        }
			

		currentState = patrolState;
	}


	void Start (){
		currentState = patrolState;
	}

	void Update (){
		currentState.UpdateState ();
		posPlayer = this.transform.position;
	}

	public void TakeDamage(float damage)
	{
		if(lifeBar != null && lifeBar.TakeDamage(damage)) //La vida ha llegado a 0
		{
			lifeBar.DisableHealthBar();
			currentState.ToDiedState();
		}
	}

	public void SightTriggered(Collider2D other) {
		if (!parasitado && !muerto) {
			target = other.transform;
			currentState.ToChaseState ();
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
			other.GetComponent<PlayerInput>().ToCanControl();
		}
	}

	public void ControlZoneStay(Collider2D other)
	{
		if(other.tag == "Player" && !muerto)
		{
			if(Input.GetKeyDown(KeyCode.E))
			{
				controlledState.parasito = other.GetComponent<PlayerInput>();
				controlledState.parasito.Parasitar(theController);
				canPatrol = false;
				StartCoroutine (WaitForParasitar ());
				currentState.ToControlledState();
			}
		}
	}

	public void ExitControlZone(Collider2D other)
	{
		if(other.tag == "Player" && !muerto && !parasitado)
		{
			other.GetComponent<PlayerInput>().ExitControlZone();
		}
	}

	private IEnumerator WaitForParasitar(){
		yield return new WaitForSeconds(1.3f);
		lifeBar.EnableHealthBar();
		parasitado = true;
	}

	void OnTriggerEnter2D(Collider2D other){
		Debug.Log ("Colisionado" + " - " + parado + " - " + other.tag + " - " + currentState);
		if (other.tag == "vomit" && !parado && currentState != controlledState) {
			aux = this.GetComponent<NpcMovement> ().movementController.moveSpeed;
			this.GetComponent<NpcMovement> ().movementController.moveSpeed = 0;
			parado = true;
			StartCoroutine (WaitForVomit ());
		}
	}

	private IEnumerator WaitForVomit(){
		yield return new WaitForSeconds(4f);
		parado = false;
		Debug.Log (parado);
		this.GetComponent<NpcMovement> ().movementController.moveSpeed = aux;
	}

	private IEnumerator Respawn()
	{
		yield return new WaitForSeconds(3f);
        DestroyObject(this.gameObject);
	}
}