using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestGun : MonoBehaviour 
{

	public Transform PlayerPos;
	public GameObject Player;

	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}

	void OnTriggerEnter2D(Collider2D col) 
	{
		if (col.gameObject.tag == "Team1" || col.gameObject.tag == "Team2")
		{
			Player = col.gameObject;
			//Player.GetComponent<Movement> ().laserBeam = true;
			Player.GetComponent<Movement> ().grenadePickUp = true;
			Destroy (this.gameObject);
			print ("LASERBEAM");

		}



	}
}
