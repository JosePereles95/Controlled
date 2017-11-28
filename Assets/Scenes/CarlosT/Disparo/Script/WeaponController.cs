using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour {
    public GameObject balaReference;
    public int ammoAmount;
    private List<GameObject> balas;

	// Use this for initialization
	void Start () {
		for(int i = 0; i < ammoAmount; i++)
        {
            GameObject newBullet = (GameObject)Instantiate(balaReference);
            newBullet.SetActive(false);
            balas.Add(newBullet);
        }
	}
	
	//Sacar bala del cargador
    public GameObject GetBullet()
    {
        for (int i = 0; i < balas.Count; i++)
            if (balas[i].activeInHierarchy == false)
                return balas[i];

        GameObject newBullet = (GameObject)Instantiate(balaReference);
        newBullet.SetActive(false);
        balas.Add(newBullet);

        return newBullet;
    }
}
