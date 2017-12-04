using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class monoTutorial : MonoBehaviour {

	public Transform[] wayPoints;
	public float speed;
	public static bool moverse = false;
	public GameObject playerVuJ;

	int next = 0;
	bool soloUnaVez = true;
	Animator anim;

	void Start()
	{
		anim = GetComponent<Animator>();
		playerVuJ.GetComponent<PlayerInput>().enabled = false;
		//this.gameObject.SetActive(false);
	}

	/*private void OnTriggerStay2D(Collider2D collision)
	{
		if (collision.gameObject.tag == "AlienSalvaje" && perseguir == true)
		{
			SceneManager.LoadScene(1);
		}
	}*/

	void Update()
	{
		if (moverse == true)
		{
			if (soloUnaVez) 
			{
				Flip ();
				soloUnaVez = false;
			}

			anim.SetBool("isWalking", true);

			float step = speed * Time.deltaTime;

			if (transform.position == wayPoints[next].position && next < wayPoints.Length -1)
				next++;

			if(next == 1)
			{
				this.gameObject.SetActive(false);
			}

			transform.position = Vector3.MoveTowards(transform.position, wayPoints[next].position, step);
		}
	}

	private void Flip()
	{
		Vector3 theScale = this.transform.localScale;
		float thePosition = transform.localPosition.x;

		transform.localPosition = new Vector3(thePosition, transform.localPosition.y, transform.localPosition.z);

		theScale.x *= -1;
		this.transform.localScale = theScale;
	}
}
