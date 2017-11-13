using UnityEngine;

[RequireComponent(typeof(Player))]
public class PlayerInput : MonoBehaviour
{
    private Player player;
    private string playerState;
    private Player controlledTripulant;
    public GameObject vujBody;
    public GameObject canControlFlag;

    private void Start()
    {
        player = GetComponent<Player>();
        playerState = "NotControlling";
        canControlFlag.SetActive(false);
    }

    private void Update()
    {
        switch (playerState)
        {
            case "CanControl":
                if(Input.GetKeyDown(KeyCode.E)) Parasitar();

                else ControlVUJ();
                break;
            case "NotControlling":
                ControlVUJ();
                break;
            case "Controlling":
                if (Input.GetKeyDown(KeyCode.E)) Desparasitar();
                else
                {
                    ControlTripulant();
                    transform.position = controlledTripulant.transform.position;
                }
                break;
        }
    }

    private void ControlVUJ()
    {
         Vector2 directionalInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        player.SetDirectionalInput(directionalInput);

        if (Input.GetButtonDown("Jump"))
        {
            player.OnJumpInputDown();
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

        if (Input.GetButtonDown("Jump"))
        {
            controlledTripulant.OnJumpInputDown();
        }

        if (Input.GetButtonUp("Jump"))
        {
            controlledTripulant.OnJumpInputUp();
        }
    }

    private void Parasitar()
    {
        if (canControlFlag.activeInHierarchy == true) canControlFlag.SetActive(false);

        player.enabled = false;
        vujBody.SetActive(false);
        playerState = "Controlling";
    }

    private void Desparasitar()
    {
        controlledTripulant.SetDirectionalInput(new Vector2(0, 0));
        player.enabled = true;
        vujBody.SetActive(true);
        playerState = "NotControlling";
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "TripB" && playerState == "NotControlling")
        {
            controlledTripulant = other.gameObject.GetComponent<Player>();
            canControlFlag.SetActive(true);
            playerState = "CanControl";
        }

    }

    private void OnTriggerExit2D(Collider2D other)
    {
       if(other.tag == "TripB" && playerState == "CanControl")
        {
            canControlFlag.SetActive(false);
            controlledTripulant = null;
            playerState = "NotControlling";
        }
    }
}
