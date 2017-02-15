//Written By Saoirse
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour {

	public static bool objectiveHeld = false;
	public bool hasObjective = false;
	public bool Respawning = false;
	public float coolDown = 50f;
	public Transform spawnPoint;
	//	public GameObject objective;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

	}

	void OnTriggerEnter2D(Collider2D col) {
		Quaternion down = Quaternion.Euler(0,0,0);


		if (col.gameObject.tag == "Bullet") {
			if(Respawning == false){
				StartCoroutine (respawning ());
				if (hasObjective) {
					hasObjective = false;
					objectiveHeld = false;
					transform.DetachChildren ();
				}
				transform.position = spawnPoint.position;
				gameObject.GetComponent<Rigidbody2D> ().velocity = Vector2.zero;
				transform.rotation = down;			
				Physics2D.gravity = new Vector2 (1f,-9.8f);
			}
		}
	}
	/*
	void OnCollisionEnter2D(Collision2D col) {
		if (col.gameObject.tag == "Objective") {
			if (Respawning == false) {
				print ("got it");
				objectiveHeld = true;
				objective = col.gameObject;
				objective.transform.SetParent (this.transform);
			}
		}
	}
	*/

	public IEnumerator respawning() {
		Respawning = true;
		print ("Respawning is " + Respawning);
		yield return new WaitForSeconds (3f);
		Respawning = false;
		print ("Respawning is " + Respawning);
	}
}
