using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Player))]
public class PlayerInput : MonoBehaviour
{
    public AudioClip parasitar;
    AudioSource fuenteAudio;

    private Player player;

	public Animator anim;
	private bool facingRight; //variable para saber si el sprite mira a la derecha

	private NpcMovement controlledTripulant;
	public GameObject vujBody;
	public GameObject canControlFlag;

	public VujStates playerState;

	private CameraFollow theCamera;


    private void Start()
	{
        fuenteAudio = GetComponent<AudioSource>();

        player = GetComponent<Player>();
		//anim = GetComponent<Animator>();
		theCamera = FindObjectOfType<CameraFollow>();

		playerState = VujStates.NotControlling;
		canControlFlag.SetActive(false);

		facingRight = false; //al principio no mira a la derecha
                             //Flip(1); //lo giramos para que mire a la derecha
	}

	private void Update()
	{

		switch (playerState)
		{
		    case VujStates.CanControl:
		    case VujStates.NotControlling:
			    ControlVuj();
			    break;
		    case VujStates.Controlling:
			    ControlTripulant();
			    if(controlledTripulant != null) transform.position = controlledTripulant.transform.position;
			    break;
            default:
                break;
		}

		CheckInvisibility ();

	}

	//Detecta la orientacion del sprite y la cambia
	private void Flip(float horizontal)
	{
		if (horizontal > 0 && !facingRight || horizontal < 0 && facingRight)
		{
			facingRight = !facingRight;

			Vector3 theScale = vujBody.transform.localScale;
			float thePosition = transform.localPosition.x;

			transform.localPosition = new Vector3(thePosition, transform.localPosition.y, transform.localPosition.z);

			theScale.x *= -1;
			vujBody.transform.localScale = theScale;
		}
	}

	private void ControlVuj()
	{
		//Guardamos en un vector si se mueve en algún eje y aplicamos el movimiento
		Vector2 directionalInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
		player.SetDirectionalInput(directionalInput);

		//si el movimiento en el eje X giramos el sprite
		if (directionalInput[0] != 0)
		{
			anim.SetBool("isWalking", true);
			Flip(directionalInput[0]);
		}
		else
		{
			anim.SetBool("isWalking", false);
		}

		if (player.IsGrounded())
			anim.SetBool("isJumping", false);

		//Para el salto. Las funciones están en Player.cs
		if (Input.GetButtonDown("Jump"))
		{
			player.OnJumpInputDown();

			anim.SetBool("isJumping", true);
		}

		if (Input.GetButtonUp("Jump"))
		{
			player.OnJumpInputUp();
		}

	}

	private void ControlTripulant()
	{
		Vector2 directionalInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
		if(controlledTripulant != null)
        {
            controlledTripulant.SetDirectionalInput(directionalInput);

            controlledTripulant.Falling();

            if (Input.GetButtonDown("Jump"))
            {
                controlledTripulant.OnJumpInputDown();
            }

            if (Input.GetButtonUp("Jump"))
            {
                controlledTripulant.OnJumpInputUp();
            }
        }
	}

	public void Parasitar(NpcMovement enemy)
	{
		if(playerState == VujStates.CanControl)
		{
            controlledTripulant = enemy;
            playerState = VujStates.OnControlling;

			if (canControlFlag.activeInHierarchy == true) canControlFlag.SetActive(false);

            fuenteAudio.clip = parasitar;
            fuenteAudio.Play();

            //anim.SetBool("parasitar", true);
            controlledTripulant.Parasitar();
            StartCoroutine("Parasitando");
		}
	}

	private IEnumerator Parasitando()
	{
		player.enabled = false;
		vujBody.SetActive(false);
		theCamera.target = controlledTripulant.GetComponent<Controller2D>();

		yield return new WaitForSeconds(1.0f);

		playerState = VujStates.Controlling;

	}

	public void Desparasitar()
	{
        if(controlledTripulant != null) controlledTripulant.SetDirectionalInput(new Vector2(0, 0));
        anim.SetBool("parasitar", false);
		player.enabled = true;
		vujBody.SetActive(true);
		theCamera.target = this.GetComponent<Controller2D>();
        controlledTripulant = null;
        playerState = VujStates.NotControlling;
    }

	public void ToCanControl()
	{
		if(playerState == VujStates.NotControlling)
		{
			canControlFlag.SetActive(true);
			playerState = VujStates.CanControl;
		}
	}

	public void ExitControlZone()
	{
		if(playerState == VujStates.CanControl)
		{
			canControlFlag.SetActive(false);
			playerState = VujStates.NotControlling;
		}
	}


	//Enumerator para comparar los estados de Vuj
	public enum VujStates
	{
		NotControlling, CanControl, Controlling, Dead, OnControlling

	}

	private void CheckInvisibility(){
		if (this.tag == "Player") {
			if (playerState == VujStates.Controlling || player.enabled == false)
				this.GetComponent<Invisibility> ().enabled = false;
			else
				this.GetComponent<Invisibility> ().enabled = true;
		}
	}
}