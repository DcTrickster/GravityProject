using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeFolow : MonoBehaviour {

	public Transform Player;
	public float followSpeed = 1f;
	private Vector3 offSetVector;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		offSetVector = new Vector3 (Player.position.x + 0.5f, Player.position.y + 0.5f, Player.position.z);
		transform.position += (offSetVector - transform.position) * followSpeed;
	}

}
