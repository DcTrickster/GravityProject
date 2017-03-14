//Written By Saoirse
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Objective : MonoBehaviour {

	public Transform PlayerPos;
	public GameObject Player;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

	}

	void OnTriggerEnter2D(Collider2D col) {
		if (col.gameObject.tag == "Team1" || col.gameObject.tag == "Team2") {
			if (Respawn.objectiveHeld == false){
				Player = col.gameObject;
				if (Player.GetComponent<Respawn> ().Respawning == false) {
					print ("Got it");
					Player.GetComponent<Respawn> ().hasObjective = true;
					PlayerPos = col.GetComponent<Collider2D>().gameObject.transform;
					gameObject.transform.SetParent (PlayerPos);
					Respawn.objectiveHeld = true;
				}
			}
		}
	}

}
