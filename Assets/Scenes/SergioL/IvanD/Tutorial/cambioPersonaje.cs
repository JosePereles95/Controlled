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
    bool caida = false;

    void Start()
    {
        anim = alienTutoAnim.GetComponent<Animator>();
        trans = playerVuJ.GetComponent<Transform>();

        playerVuJ.GetComponent<PlayerInput>().enabled = false;
        playerVuJ.GetComponent<Controller2D>().enabled = false;
        playerVuJ.GetComponent<Player>().enabled = false;

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
            }

            trans.position = Vector3.MoveTowards(trans.position, wayPoints[next].position, step);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "AlienSalvaje")
        {
            CameraFollow.cambiarVUJ = true;

            anim.SetBool("isWalking", false);

            alienTuto.GetComponent<PlayerInput>().enabled = false;
            alienTuto.GetComponent<Controller2D>().enabled = false;
            alienTuto.GetComponent<Player>().enabled = false;

            for (int i = 0; i < listSprites.Length; i++)
            {
                listSprites[i].GetComponent<SkinnedMeshRenderer>().enabled = true;
            }

            caida = true;
        }
    }
}
