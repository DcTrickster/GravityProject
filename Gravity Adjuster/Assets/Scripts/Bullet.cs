using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour 
{
	public float startTimer = 0f;
	public GameObject team1;
	public GameObject team2;


	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void FixedUpdate () 
	{
		startTimer++;

		if (startTimer == 50f) 
		{
			Destroy (this.gameObject);
		}
	}

	void OnCollisionEnter2D (Collision2D col)
	{
		Destroy (this.gameObject);
	}
		


}
