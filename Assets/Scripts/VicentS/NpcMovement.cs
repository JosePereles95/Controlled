using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Player))]
public class NpcMovement : MonoBehaviour {
    public Animator anim;
	private GameObject shootingArm;

    public bool facingRight; //Variable para saber si el sprite mira a la derecha

    //Script de comportamiento de movimiento
    private Player movementController;

	// Use this for initialization
	void Start () {
		shootingArm = GameObject.FindGameObjectWithTag ("shootingArm");
        movementController = GetComponent<Player>();
		anim = GetComponent<Animator> ();
        Flip(1); //lo giramos para que mire a la derecha
    }


	void Update(){
		if (this.GetComponentInChildren<ControlledZone>() != null) {
			if (GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInput>().playerState == PlayerInput.VujStates.Controlling) {
				shootingArm.GetComponent<gunControl> ().enabled = true;
			}
			else if (GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInput>().playerState == PlayerInput.VujStates.NotControlling) {
				shootingArm.GetComponent<gunControl> ().enabled = false;
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
        movementController.SetDirectionalInput(directionalInput);
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
    }

    public void OnJumpInputDown()
    {
        movementController.OnJumpInputDown();
		anim.SetBool("isJumping", true);
    }

    public void OnJumpInputUp()
    {
        movementController.OnJumpInputUp();
    }

    public void IsGrounded()
    {
        if(movementController.IsGrounded())
            anim.SetBool("isJumping", false);
    }

    public void Parasitar()
    {
        anim.SetTrigger("parasitado");
    }

    public void Die()
    {
        anim.SetTrigger("muerto");
    }
}
