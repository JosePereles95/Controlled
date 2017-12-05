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

    private void InitCharacter()
    {
        theController = GetComponent<NpcMovement>();
        parado = false;
        patrolState = new PatrolState(this, theController);
        chaseState = new ChaseState(this, theController);
        controlledState = new ControlledState(this, theController);
        diedState = new DiedState(this, theController);

        //Life Initialitation
        lifeBar = GetComponent<TankHealth>();
        lifeBar.m_StartingHealth = vidaInicial;
        lifeBar.DisableHealthBar();

        //Bool init
        parasitado = false;
        muerto = false;
        canPatrol = true;

        theController.anim.SetBool("isDead", false);

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
        if(lifeBar.TakeDamage(damage)) //La vida ha llegado a 0
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
            other.GetComponent<PlayerInput>().ToCanControl(theController);
        }
    }

    public void ControlZoneStay(Collider2D other)
    {
		if(other.tag == "Player" && !muerto)
        {
            if(Input.GetKeyDown(KeyCode.E))
            {
				controlledState.parasito = other.GetComponent<PlayerInput>();
                controlledState.parasito.Parasitar();
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
        lifeBar.EnableHealthBar();
		parasitado = true;
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.tag == "vomit" && !parado && currentState != controlledState) {
			this.GetComponent<NpcMovement> ().movementController.moveSpeed = 0;
			parado = true;
			StartCoroutine (WaitForVomit ());
		}
	}

	private IEnumerator WaitForVomit(){
		yield return new WaitForSeconds(4f);
		parado = false;
		this.GetComponent<NpcMovement> ().movementController.moveSpeed = 4;
	}

    private IEnumerator Respawn()
    {
        yield return new WaitForSeconds(3f);
        this.gameObject.SetActive(false);
    }
}