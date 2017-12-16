using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cambioPersonaje : MonoBehaviour {

    public GameObject alienTuto;
    public GameObject alienTutoAnim;
    public GameObject playerVuJ;

    Animator anim;
    Transform trans;

    public SkinnedMeshRenderer[] listSprites;
    public Transform[] wayPoints;

    public float speed;
    int next = 0;
    public bool caida = false;

    void Start()
    {
        anim = alienTutoAnim.GetComponent<Animator>();
        trans = playerVuJ.GetComponent<Transform>();

        playerVuJ.GetComponent<PlayerInput>().enabled = false;
        playerVuJ.GetComponent<Controller2D>().enabled = false;
        playerVuJ.GetComponent<Player>().enabled = false;
		playerVuJ.GetComponent<Invisibility>().enabled = false;

        for (int i = 0; i < listSprites.Length; i++)
        {
            listSprites[i].GetComponent<SkinnedMeshRenderer>().enabled = false;
        }
    }

    void Update()
    {
        float step = speed * Time.deltaTime + Time.deltaTime;

        if(caida == true)
        {
            if (trans.position == wayPoints[next].position && next < wayPoints.Length - 1)
                next++;
            else if(trans.position == wayPoints[wayPoints.Length -1].position)
            {
                caida = false;

                playerVuJ.GetComponent<PlayerInput>().enabled = true;
                playerVuJ.GetComponent<Controller2D>().enabled = true;
                playerVuJ.GetComponent<Player>().enabled = true;
				playerVuJ.GetComponent<Invisibility>().enabled = true;
            }

            trans.position = Vector3.MoveTowards(trans.position, wayPoints[next].position, step);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "AlienSalvaje")
        {
            anim.SetBool("isDead", true);
            anim.SetBool("isWalking", false);
<<<<<<< HEAD
			anim.Play ("Dead");
=======
>>>>>>> 912a1225e242a34e188bfee8915dff5c924c760a

            alienTuto.GetComponent<PlayerInput>().enabled = false;
            alienTuto.GetComponent<Controller2D>().enabled = false;
            alienTuto.GetComponent<Player>().enabled = false;

            StartCoroutine(Wait());
        }
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(0.9f);

        caida = true;

        CameraFollow.cambiarVUJ = true;

        for (int i = 0; i < listSprites.Length; i++)
        {
            listSprites[i].GetComponent<SkinnedMeshRenderer>().enabled = true;
        }
    }
}
