using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpriteFlipperParent : MonoBehaviour 
{
	public bool facingRight = false;
	private Rigidbody2D body;

	public SpriteRenderer mySpriteRenderer;


	private List<SpriteFlipperChild> flippers;

	// Use this for initialization
	void Awake () 
	{
		body = GetComponent<Rigidbody2D> ();
		mySpriteRenderer = GetComponent<SpriteRenderer> ();

	}

	void Start ()
	{
	}

	// Update is called once per frame
	void Update () 
	{
		TestfacingRight ();
	}

	void TestfacingRight (bool force = false)
	{
		if (body.velocity.x > 0 && (facingRight == false || force)) 
		{
			facingRight = true;
			mySpriteRenderer.flipX = false;
		}
		else if (body.velocity.x < 0 && (facingRight == true || force))
		{
			facingRight = false;
			mySpriteRenderer.flipX = true;
		}
	}
		
}
