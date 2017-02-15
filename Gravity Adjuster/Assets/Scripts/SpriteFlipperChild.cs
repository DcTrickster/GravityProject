using UnityEngine;
using System.Collections;

public class SpriteFlipperChild : MonoBehaviour 
{
	public SpriteRenderer mySpriteRenderer;

	// Use this for initialization
	void Start () 
	{
		mySpriteRenderer = GetComponent<SpriteRenderer> ();
	}
	
	// Update is called once per frame
	public void Flip (bool facingRight) 
	{
		mySpriteRenderer.flipX = !facingRight;
	}
}
