using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour {

    public int nPersonajes;
    public GameObject personaje;
    public Transform spawnPos;

    private List<GameObject> personajes;
    private Animator anim;

    private int spawnHash = Animator.StringToHash("Spawn");

    public bool spawn;

	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();

        //Cargar personajes
        personajes = new List<GameObject>();

        for(int i = 0; i < nPersonajes+2; i++)
        {
            GameObject newCharacter = (GameObject)Instantiate(personaje);
            newCharacter.SetActive(false);
            newCharacter.GetComponent<StateEnemyBehavior>().spawnPoint = this;
            personajes.Add(newCharacter);
        }
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
        spawnedChar.SetActive(true);

    }

    private GameObject GetCharacter()
    {
       for (int i = 0; i < personajes.Count; i++)
            if (personajes[i].activeInHierarchy == false)
                return personajes[i];

        GameObject newCharacter = (GameObject)Instantiate(personaje);
        newCharacter.SetActive(false);
        personajes.Add(newCharacter);

        return newCharacter;
    }
}
