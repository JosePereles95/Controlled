﻿using UnityEngine;

[RequireComponent(typeof(Player))]
public class PlayerInput : MonoBehaviour
{
    private Player player;
    private bool facingRight; //variable para saber si el sprite mira a la derecha

    private void Start()
    {
        player = GetComponent<Player>();
        facingRight = false; //al principio no mira a la derecha
        Flip(1); //lo giramos para que mire a la derecha
    }

    private void Update()
    {
        //Guardamos en un vector si se mueve en algún eje y aplicamos el movimiento
        Vector2 directionalInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        player.SetDirectionalInput(directionalInput);

        //si el movimiento en el eje X giramos el sprite
        if (directionalInput[0] != 0)
        {
            Flip(directionalInput[0]);
        }

        //Para el salto. Las funciones están en Player.cs
        if (Input.GetButtonDown("Jump"))
        {
            player.OnJumpInputDown();
        }

        if (Input.GetButtonUp("Jump"))
        {
            player.OnJumpInputUp();
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
