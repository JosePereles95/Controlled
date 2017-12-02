using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerShoot : MonoBehaviour
{
<<<<<<< HEAD
=======
    //public Transform[] wayPoints;
    //public float speed;
    //int next = 0;
>>>>>>> a8f1a5bf6eac4acc03c23fb766740b2a75af9274
    Animator anim;

    private LineRenderer lr;
    private Transform lrPos;

    public GameObject bullet;
    public LayerMask layerMask;
    float range = 100f;

    Vector2 direccion;

<<<<<<< HEAD
=======
    private bool facingRight = false;

>>>>>>> a8f1a5bf6eac4acc03c23fb766740b2a75af9274
    void Start()
    {
        lr = bullet.GetComponent<LineRenderer>();
        lrPos = bullet.GetComponent<Transform>();
        anim = GetComponent<Animator>();
    }

<<<<<<< HEAD
    void Update()
    {
        Shoot();
    }

=======
>>>>>>> a8f1a5bf6eac4acc03c23fb766740b2a75af9274
    void Shoot()
    {
        Vector2 firePos = new Vector2(lrPos.position.x, lrPos.position.y);

<<<<<<< HEAD
        if (this.transform.localScale.x > 0)
=======
        if(this.transform.localScale.x > 0)
>>>>>>> a8f1a5bf6eac4acc03c23fb766740b2a75af9274
        {
            direccion = new Vector2(-1, -0.2f);
        }
        else
        {
            direccion = new Vector2(1, -0.2f);
        }

        RaycastHit2D hit = Physics2D.Raycast(firePos, direccion, range, layerMask);

        //Debug.DrawRay(firePos, direccion * range, Color.blue, 1f);

        if (hit.collider)
        {
            lr.SetPosition(1, new Vector3(hit.distance, 0, 0));
        }
        else
        {
            lr.SetPosition(1, new Vector3(100, 0, 0));
        }
<<<<<<< HEAD

        if (hit.collider.gameObject.tag == "Player")
        {
            print("Estas muerto. Laser.");
        }
    }

=======
    }

    void Update()
    {
        Shoot();

        /*float step = speed * Time.deltaTime + Time.deltaTime;

        if (transform.position == wayPoints[0].position)
        {
            next++;
            print("holaaaaa");
            //FlipDroide(1);
        }
        else if(transform.position == wayPoints[1].position)
        {
            next--;
            //FlipDroide(-1);
        }

        transform.position = Vector3.MoveTowards(transform.position, wayPoints[next].position, step);*/
    }

    private void FlipDroide(float horizontal)
    {
        if (horizontal > 0 && !facingRight || horizontal < 0 && facingRight)
        {
            facingRight = !facingRight;

            Vector3 theScale = this.transform.localScale;
            float thePosition = this.transform.localPosition.x;

            this.transform.localPosition = new Vector3(thePosition, this.transform.localPosition.y, this.transform.localPosition.z);

            theScale.x *= -1;
            this.transform.localScale = theScale;
        }
    }
>>>>>>> a8f1a5bf6eac4acc03c23fb766740b2a75af9274
}
