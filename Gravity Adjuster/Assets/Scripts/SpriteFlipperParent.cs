using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpriteFlipperParent : MonoBehaviour 
{
	public bool facingRight = false;
	private Rigidbody2D body;

	public SpriteRenderer mySpriteRendererTop;
	public SpriteRenderer mySpriteRendererLegs;



	private List<SpriteFlipperChild> flippers;

	// Use this for initialization
	void Awake () 
	{
		body = GetComponentInParent<Rigidbody2D> ();
		mySpriteRendererTop = GetComponent<SpriteRenderer> ();
		mySpriteRendererLegs = GetComponent<SpriteRenderer> ();

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
			mySpriteRendererTop.flipX = false;
			mySpriteRendererLegs.flipX = false;

		}
		else if (body.velocity.x < 0 && (facingRight == true || force))
		{
			facingRight = false;
			mySpriteRendererTop.flipX = true;
			mySpriteRendererLegs.flipX = true;

		}
	}
		
}
