using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour 
{
	public float startTimer = 0f;
	public GameObject team1;
	public GameObject team2;
	public GameObject GrenadeShot;

	// Use this for initialization
	void Start () 
	{
	}
	
	// Update is called once per frame
	void FixedUpdate () 
	{

	}

	void OnTriggerEnter2D (Collider2D col)
	{
		if (col.gameObject.tag == "Obstacle" || col.gameObject.tag == "Team1" || col.gameObject.tag == "Team2")
		{
			Debug.Log ("Hit!");
			Destroy (this.gameObject);
		}

		if (col.gameObject.name == "Grenade1" || col.gameObject.name == "Grenade2") 
		{
//			col.gameObject = GrenadeShot;
			col.gameObject.GetComponent<Grenade> ().detonate = true;		
		}
	}
		


}
