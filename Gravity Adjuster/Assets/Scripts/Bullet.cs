using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour 
{
	public float startTimer = 0f;


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

	void OnCollisionEnter (Collider Col)
	{
	}

}
