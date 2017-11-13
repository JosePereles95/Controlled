using UnityEngine;

[RequireComponent(typeof(Player))]
public class PlayerInput : MonoBehaviour
{
    private Player player;
    private Animator anim;
    private bool jumping = false;

    private void Start()
    {
        player = GetComponent<Player>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        Vector2 directionalInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        player.SetDirectionalInput(directionalInput);

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
}
