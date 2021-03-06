﻿//Written By Saoirse
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour {

	public static bool objectiveHeld = false;
	public static bool goal1 = false;
	public static bool goal2 = false;
	public bool hasObjective = false;
	public bool Respawning = false;
	public float coolDown = 50f;
	public Transform spawnPoint;
	public Transform heldObject;

	AudioSource Sounds;
	public AudioClip respawnSound;
	public AudioClip deathSound;

	public int lives = 3;

	// Use this for initialization
	void Start () {

		Sounds = gameObject.GetComponent<AudioSource> ();


	}

	// Update is called once per frame
	void Update () {

		heldObject = transform.FindChild ("Objective");

		if(lives < 1){
			Destroy (this.gameObject);
		}
	}

	void OnTriggerEnter2D(Collider2D col) {
		Quaternion down = Quaternion.Euler(0,0,0);

		if (col.gameObject.tag == "Bullet" && gameObject.tag == "Team2") 
		{
			if(Respawning == false){
				StartCoroutine (respawning ());
				if (hasObjective) {
					hasObjective = false;
					objectiveHeld = false;
					heldObject.parent = null;
					Sounds.PlayOneShot (respawnSound);

				}
				transform.position = spawnPoint.position;
				gameObject.GetComponent<Rigidbody2D> ().velocity = Vector2.zero;
				transform.rotation = down;			
				Physics2D.gravity = new Vector2 (1f,-9.8f);

				lives--;
				if (gameObject.name == "Player1" || gameObject.name == "Player2") {
					Goal.RedLives--;
				}
				if (gameObject.name == "Player3" || gameObject.name == "Player4") {
					Goal.BlueLives--;
				}
			}
		}

		if (col.gameObject.tag == "Bullet2" && gameObject.tag == "Team1") 
		{
			if(Respawning == false){
				StartCoroutine (respawning ());
				if (hasObjective) {
					hasObjective = false;
					objectiveHeld = false;
					heldObject.parent = null;
					Sounds.PlayOneShot (respawnSound);

				}
				transform.position = spawnPoint.position;
				gameObject.GetComponent<Rigidbody2D> ().velocity = Vector2.zero;
				transform.rotation = down;			
				Physics2D.gravity = new Vector2 (1f,-9.8f);

				lives--;
				if (gameObject.name == "Player1") {
					Goal.P1Lives--;
				}
				if (gameObject.name == "Player2") {
					Goal.P2Lives--;
				}
				if (gameObject.name == "Player3") {
					Goal.P3Lives--;
				}
				if (gameObject.name == "Player4") {
					Goal.P4Lives--;
				}
			}
		}

		if(col.gameObject.tag == "Goal2" && (gameObject.name == "Player3" || gameObject.name == "Player4")) {
			if(hasObjective == true) {
				goal2 = true;
			}
		}
		if(col.gameObject.tag == "Goal1" && (gameObject.name == "Player1" || gameObject.name == "Player2")) {
			if(hasObjective == true) {
				goal1 = true;
			}
		}
	}

	public IEnumerator respawning() {
		Respawning = true;
		Sounds.PlayOneShot (deathSound);
		print ("Respawning is " + Respawning);
		yield return new WaitForSeconds (3f);
		Respawning = false;
		Sounds.PlayOneShot (respawnSound);
		print ("Respawning is " + Respawning);
	}
}
