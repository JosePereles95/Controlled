using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gunControl : MonoBehaviour {
    Rigidbody2D rb;
    public Transform brazo;
    public Transform pistola;
    public Transform firePoint;
    Vector2 dir;
    float angle;
    float lastAngle;

    private NpcMovement theController;
    public WeaponController cargador;

    public float maxAngle;
    public float minAngle;

    public float fireRate = 0;
    public float Damage = 10;
    public LayerMask whatToHit;

    public Transform BulletTrailPrefab;
    float timeToSpawnEffect = 0;
    public float effectSpawnRate = 10;

    float timeToFiere = 0;
    //Transform firePoint;

<<<<<<< HEAD

=======
>>>>>>> JoseP
    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody2D>();
        theController = GetComponentInParent<NpcMovement>();
        //brazo.localEulerAngles = Vector3.forward;
	}

<<<<<<< HEAD
    void Awake()
    {
        //firePoint = transform.Find("FirePoint");
        if (firePoint == null)
        {
=======
    void Awake() {
        //firePoint = transform.Find("FirePoint");
        if (firePoint == null) {
>>>>>>> JoseP
            Debug.LogError("No firePoint? WHAT?!");
        }
    }

    // Update is called once per frame
    void LateUpdate () {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        dir = mousePos - transform.position;

<<<<<<< HEAD
        if (!theController.facingRight)             //Comprobar a que lado esta mirando el personaje
        {
=======
		if (!theController.facingRight) {  //Comprobar a que lado esta mirando el personaje
>>>>>>> JoseP
            dir *= -1;
        }
        angle =Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;

<<<<<<< HEAD
        if (angle < maxAngle && angle > minAngle) //Comprabar que el angulo se encuentre en el espacio que queremos
        {
=======
		if (angle < maxAngle && angle > minAngle) {//Comprabar que el angulo se encuentre en el espacio que queremos
>>>>>>> JoseP
            //rb.MoveRotation(angle);
            if (theController.facingRight)
                lastAngle = angle;
            else
                lastAngle = -1 *  angle;
        }
        
        brazo.localEulerAngles = brazo.localEulerAngles + new Vector3(0, 0, lastAngle+90);

<<<<<<< HEAD
        if (fireRate == 0)
        {
            if (Input.GetButtonDown("Fire1"))
            {
=======
        if (fireRate == 0) {
            if (Input.GetButtonDown("Fire1")) {
>>>>>>> JoseP
                Shoot();
            }
        }

<<<<<<< HEAD
        else
        {
            if (Input.GetButtonDown("Fire1") && Time.time > timeToFiere)
            {
=======
        else {
            if (Input.GetButtonDown("Fire1") && Time.time > timeToFiere) {
>>>>>>> JoseP
                timeToFiere = Time.time + 1 / fireRate;
                Shoot();
            }
        }

    }

    void Shoot()
    {
        Vector2 mousePosition = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y);
        Vector2 firePointPosition = new Vector2(firePoint.position.x, firePoint.position.y);
        RaycastHit2D hit = Physics2D.Raycast(firePointPosition, mousePosition - firePointPosition, 100, whatToHit);
<<<<<<< HEAD
        if (Time.time >= timeToSpawnEffect)
        {
=======
        
		if (Time.time >= timeToSpawnEffect) {
>>>>>>> JoseP
            Effect();
            timeToSpawnEffect = Time.time + 1 / effectSpawnRate;
        }
        Debug.DrawLine(firePointPosition, (mousePosition - firePointPosition) * 100, Color.cyan);
<<<<<<< HEAD
        if (hit.collider != null)
        {
=======
        if (hit.collider != null) {
>>>>>>> JoseP
            Debug.DrawLine(firePointPosition, hit.point, Color.red);
            Debug.Log("We hit " + hit.collider.name + " an did " + Damage + " damage");
        }
    }

    void Effect()
    {
<<<<<<< HEAD
        if (theController.facingRight)
        {
            Instantiate(BulletTrailPrefab, firePoint.position, brazo.rotation);
        }
        else
        {
=======
        if (theController.facingRight){
            Instantiate(BulletTrailPrefab, firePoint.position, brazo.rotation);
        }
        else {
>>>>>>> JoseP
            Instantiate(BulletTrailPrefab, firePoint.position, Quaternion.Euler(brazo.rotation.eulerAngles + new Vector3(0, 0, 180)));
        }
    }
}
