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
    private VujStates playerState;

    private void Start()
    {
        player = GetComponent<Player>();
        //anim = GetComponent<Animator>();

        playerState = VujStates.NotControlling;
        canControlFlag.SetActive(false);

        facingRight = false; //al principio no mira a la derecha
        Flip(1); //lo giramos para que mire a la derecha
    }

    private void Update()
    {
          switch (playerState)
        {
            case VujStates.CanControl:
                if(Input.GetKeyDown(KeyCode.E)) Parasitar();

                else ControlVuj();
                break;
            case VujStates.NotControlling:
                ControlVuj();
                break;
            case VujStates.Controlling:
                if (Input.GetKeyDown(KeyCode.E)) Desparasitar();
                else
                {
                    ControlTripulant();
                    transform.position = controlledTripulant.transform.position;
                }
                break;
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

            transform.localPosition = new Vector3(thePosition, transform.localPosition.y, transform.localPosition.z);

            theScale.x *= -1;
            transform.localScale = theScale;
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

        //Para el salto. Las funciones están en Player.cs
        if (Input.GetButtonDown("Jump"))
        {
            player.OnJumpInputDown();

            anim.SetBool("isJumping", true);
        }
        else if(Input.GetButton("Jump"))
        {
            anim.SetBool("isJumping", false);
        }

        if (Input.GetButtonUp("Jump"))
        {
            player.OnJumpInputUp();
			anim.SetBool("isJumping", false);
        }
		
	}
	
	private void ControlTripulant()
    {
        Vector2 directionalInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        controlledTripulant.SetDirectionalInput(directionalInput);

        if (Input.GetButtonDown("Jump"))
        {
            controlledTripulant.OnJumpInputDown();
        }

        else if (Input.GetButton("Jump"))
        {
            controlledTripulant.Falling();
        }

        if (Input.GetButtonUp("Jump"))
        {
            controlledTripulant.OnJumpInputUp();
        }
    }
	
    private void Parasitar()
    {
        if (canControlFlag.activeInHierarchy == true) canControlFlag.SetActive(false);
        anim.SetTrigger("parasitar");

        StartCoroutine("Parasitando");
    }

	 private IEnumerator Parasitando()
    {
        yield return new WaitForSeconds(0.2f);
        controlledTripulant.Parasitar();
        player.enabled = false;
        vujBody.SetActive(false);

        yield return new WaitForSeconds(1.0f);
        playerState = VujStates.Controlling;
    }

    private void Desparasitar()
    {
        controlledTripulant.SetDirectionalInput(new Vector2(0, 0));
        player.enabled = true;
        vujBody.SetActive(true);
        playerState = VujStates.NotControlling;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "TripB" && playerState == VujStates.NotControlling)
        {
            controlledTripulant = other.gameObject.GetComponent<NpcMovement>();
            canControlFlag.SetActive(true);
            playerState = VujStates.CanControl;
        }

    }

    private void OnTriggerExit2D(Collider2D other)
    {
       if(other.tag == "TripB" && playerState == VujStates.CanControl)
        {
            canControlFlag.SetActive(false);
            controlledTripulant = null;
            playerState = VujStates.NotControlling;
        }
    }

    //Enumerator para comparar los estados de Vuj
    private enum VujStates
    {
        NotControlling, CanControl, Controlling, Dead

    }
}