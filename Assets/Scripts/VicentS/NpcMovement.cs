using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Player))]
public class NpcMovement : MonoBehaviour {
	public Animator anim;
	public GameObject shootingArm;

	public bool facingRight; //Variable para saber si el sprite mira a la derecha

	//Script de comportamiento de movimiento
	public Player movementController;


	// Use this for initialization
	void Start () {
		if (this.GetComponentInChildren<ControlledZone>() != null && shootingArm != null)
			this.shootingArm.GetComponent<gunControl> ().enabled = false;
		this.movementController = GetComponent<Player>();
		this.anim = GetComponent<Animator> ();
		Flip(1); //lo giramos para que mire a la derecha
	}


	void Update(){
		if (this.GetComponentInChildren<ControlledZone>() != null) {
			if (GameObject.FindGameObjectWithTag ("Player")) {
				if (GameObject.FindGameObjectWithTag ("Player").GetComponent<PlayerInput> ().playerState == PlayerInput.VujStates.Controlling && 
					this.GetComponent<StateEnemyBehavior>().currentState == this.GetComponent<StateEnemyBehavior>().controlledState) {
					if(shootingArm != null)
						this.shootingArm.GetComponent<gunControl> ().enabled = true;

				} else if (GameObject.FindGameObjectWithTag ("Player").GetComponent<PlayerInput> ().playerState == PlayerInput.VujStates.NotControlling && 
					this.GetComponent<StateEnemyBehavior>().currentState != this.GetComponent<StateEnemyBehavior>().controlledState) {
					if(shootingArm != null)
						this.shootingArm.GetComponent<gunControl> ().enabled = false;
				}
			}
		}
	}

	//Detecta la orientacion del sprite y la cambia
	private void Flip(float horizontal)
	{
		if (horizontal > 0 && !facingRight || horizontal < 0 && facingRight)
		{
			facingRight = !facingRight;

			Vector3 theScale = transform.localScale;
			float thePosition = transform.localPosition.x;

			if (facingRight == false)
			{
				thePosition -= 1.5f;
			}
			else
			{
				thePosition += 1.5f;
			}

			transform.localPosition = new Vector3(thePosition, transform.localPosition.y, transform.localPosition.z);

			theScale.x *= -1;
			transform.localScale = theScale;
		}
	}

	public void SetDirectionalInput(Vector2 directionalInput)
	{
		//Introducir justo debajo lo necesario para ejecutar la animación de movimiento
		this.movementController.SetDirectionalInput(directionalInput);
		//si el movimiento en el eje X giramos el sprite
		if (directionalInput[0] != 0)
		{
			this.anim.SetBool("isWalking", true);
			Flip(directionalInput[0]);
		}
		else
		{
			this.anim.SetBool("isWalking", false);
		}
	}

	public void OnJumpInputDown()
	{
		this.movementController.OnJumpInputDown();
		this.anim.SetBool("isJumping", true);
	}

	public void OnJumpInputUp()
	{
		this.movementController.OnJumpInputUp();
	}

	public void Falling()
	{
		if(movementController.IsGrounded())
			this.anim.SetBool("isJumping", false);
	}

	public void Parasitar()
	{
		this.anim.SetTrigger("parasitado");
	}
}
