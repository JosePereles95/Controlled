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

    //Life management
    private TankHealth healthBar;
    public float initialHealth = 100f;
    private bool dead = false;

    public static StateEnemyBehavior Instance;

    private NpcMovement theController;

    public bool controlled = false;
    private PlayerInput parasite;

	void Awake(){
        theController = GetComponent<NpcMovement>();

		patrolState = new PatrolState (this, theController);
		chaseState = new ChaseState (this, theController);
        controlledState = new ControlledState(this, theController);

        healthBar = GetComponent<TankHealth>();
        healthBar.m_StartingHealth = initialHealth;
        healthBar.DisableHealthBar();
	}

	void Start (){
		currentState = patrolState;
	}

	void Update (){
		currentState.UpdateState ();
		posPlayer = this.transform.position;
	}

    //El personaje recibe daño
    public void TakeDamage(float damage)
    {
        if (healthBar.TakeDamage(damage)) //Verdadero es que el personajes tiene la vida a 0
        {
            if (controlled) Desparasitar(); //En caso de que este parasitado, se le desparasita primero
            Die();
        }
    }

    //El personaje muere
    private void Die()
    {
        //currentState.ToDeathState()
        theController.Die();
        dead = true;
    }

    //El jugador está en la zona de visión
	public void SightTriggered(Collider2D other) {
		target = other.transform;
		currentState.ToChaseState();
	}

    //El jugador sale de la zona de visión
	public void SightExit(Collider2D other) {
		currentState.ToPatrolState();
	}

    //El jugador entra a la zona desde la que puede parasitar
    public void EnterControlZone(Collider2D other)
    {
        if(!dead && other.tag == "Player")
        {
            other.GetComponent<PlayerInput>().ToCanControl(theController);
        }
    }

    //El jugador se mantiene en la zona desde la que puede parasitar
    public void ControlZoneStay(Collider2D other)
    {
        if(other.tag == "Player")
        {
            if(Input.GetKeyDown(KeyCode.E))
            {
                if (!dead && !controlled)
                {
                    parasite = other.GetComponent<PlayerInput>();
                    Parasitar();
                }
            }
        }
    }

    //El player sale de la zona desde la que puede parasitar
    public void ExitControlZone(Collider2D other)
    {
        if(other.tag == "Player")
        {
            other.GetComponent<PlayerInput>().ExitControlZone();
        }
    }

    //Parasitar al personake
    public void Parasitar()
    {
        parasite.Parasitar();
        currentState.ToControlledState();
        StartCoroutine("Parasitando");
    }

    //Desparasitar al personaje
    public void Desparasitar()
    {
        parasite.Desparasitar();
        healthBar.DisableHealthBar();
        controlled = false;
        Die();
    }

    //Corutina encargada de esperar mientras se esta parasitando al personaje y activar lo necesario cuando el tiempo pasa
    IEnumerator Parasitando()
    {
        yield return new WaitForSeconds(1f);
        controlled = true;
        healthBar.EnableHealthBar();
        //currentState.ToControlledState();
    }
}