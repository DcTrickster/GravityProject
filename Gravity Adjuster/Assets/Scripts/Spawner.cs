using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour 
{

	Rigidbody2D body;
	public GameObject guns;
	private bool weaponSpawned;

	// Use this for initialization
	void Start () 
	{
		body = transform.GetComponent<Rigidbody2D>();
		weaponSpawned = false;
	}

	void Update ()
	{
		print ("weapon spawned is " + weaponSpawned);

		if (weaponSpawned == false)
		{
			StartCoroutine (spawning ());
		}

	}

	public IEnumerator spawning() 
	{

		yield return new WaitForSeconds (3);
		SpawnWeapon();
		weaponSpawned = true;
	}

	// Update is called once per frame
	void SpawnWeapon () 
	{
		if (weaponSpawned == false)
		{
			Instantiate (guns, new Vector3 (body.transform.position.x, body.transform.position.y), guns.transform.rotation);
		}
	}

	void OnTriggerEnter2D(Collider2D col) 
	{
		StartCoroutine (Respawning ());
	}

	public IEnumerator Respawning()
	{

		yield return new WaitForSeconds (15);
		weaponSpawned = false;
	}


}
