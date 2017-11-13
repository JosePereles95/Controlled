using UnityEngine;

[RequireComponent(typeof(Player))]
public class PlayerInput : MonoBehaviour
{
    private Player player;
<<<<<<< HEAD
    Animator anim;
    private bool facingRight; //variable para saber si el sprite mira a la derecha
=======
    private Animator anim;
    private bool jumping = false;
>>>>>>> origin/CarlosH

    private void Start()
    {
        player = GetComponent<Player>();
        anim = GetComponent<Animator>();
<<<<<<< HEAD
        facingRight = false; //al principio no mira a la derecha
        Flip(1); //lo giramos para que mire a la derecha
=======
>>>>>>> origin/CarlosH
    }

    private void Update()
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
 
                anim.SetBool("Jumping", true);
                jumping = true;

        }
        else if (Input.GetButton("Jump"))
        {
                anim.SetBool("Jumping", false);
        }

        if (Input.GetButtonUp("Jump"))
        {
            player.OnJumpInputUp();
                jumping = false;

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

}
