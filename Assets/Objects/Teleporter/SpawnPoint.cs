using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour {

    public GameObject personaje;
    public Transform spawnPos;

    private Animator anim;

    private int spawnHash = Animator.StringToHash("Spawn");

    public bool spawn;

	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		if(spawn)
        {
            spawn = false;
            Spawn();
        }
	}

    public void Spawn()
    {
        anim.SetTrigger(spawnHash);
        GameObject spawnedChar = GetCharacter();
        spawnedChar.transform.position = spawnPos.position;
        spawnedChar.GetComponent<StateEnemyBehavior>().spawnPoint = this;
        spawnedChar.SetActive(true);

    }

    private GameObject GetCharacter()
    {
        GameObject newCharacter = (GameObject)Instantiate(personaje);
        newCharacter.SetActive(false);

        return newCharacter;
    }
}
