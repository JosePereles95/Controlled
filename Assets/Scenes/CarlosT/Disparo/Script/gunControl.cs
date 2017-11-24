using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gunControl : MonoBehaviour {
    Rigidbody2D rb;
    public Transform brazo;
    Vector2 dir;
    float angle;
    float lastAngle;

    private NpcMovement theController;
    public WeaponController cargador;

    public float maxAngle;
    public float minAngle;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
        theController = GetComponentInParent<NpcMovement>();
        //brazo.localEulerAngles = Vector3.forward;
	}
	
	// Update is called once per frame
	void LateUpdate () {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        dir = mousePos - transform.position;

        if (!theController.facingRight)             //Comprobar a que lado esta mirando el personaje
        {
            dir *= -1;
        }
        angle =Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;

        /*if (angle > 180 - maxAngle && angle > 180 - minAngle)
        {
            angle -= 180;
            rb.MoveRotation(angle);
        }*/


        if (angle < maxAngle && angle > minAngle) //Comprabar que el angulo se encuentre en el espacio que queremos
        {
            //rb.MoveRotation(angle);
            if (theController.facingRight)
                lastAngle = angle;
            else
                lastAngle = -1 *  angle;
        }
        
        brazo.localEulerAngles = brazo.localEulerAngles + new Vector3(0, 0, lastAngle+90);



    }

    private void Shoot(float angle)
    {
        GameObject bullet = cargador.GetBullet();
    }
}
