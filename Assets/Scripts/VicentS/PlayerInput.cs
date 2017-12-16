using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Player))]
public class PlayerInput : MonoBehaviour
{
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
			transform.position = controlledTripulant.transform.position;
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

	public void Parasitar()
	{
		if(playerState == VujStates.CanControl)
		{
			playerState = VujStates.OnControlling;
			if (canControlFlag.activeInHierarchy == true) canControlFlag.SetActive(false);
			anim.SetTrigger("parasitar");
			StartCoroutine("Parasitando");
		}
	}

	private IEnumerator Parasitando()
	{
		yield return new WaitForSeconds(0.2f);
		controlledTripulant.Parasitar();
		player.enabled = false;
		vujBody.SetActive(false);
		theCamera.target = controlledTripulant.GetComponent<Controller2D>();

		yield return new WaitForSeconds(1.0f);

		playerState = VujStates.Controlling;

	}

	public void Desparasitar()
	{
		controlledTripulant.SetDirectionalInput(new Vector2(0, 0));
		player.enabled = true;
		vujBody.SetActive(true);
		theCamera.target = this.GetComponent<Controller2D>();

		playerState = VujStates.NotControlling;
	}

	public void ToCanControl(NpcMovement enemy)
	{
		if(playerState == VujStates.NotControlling)
		{
			controlledTripulant = enemy;
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