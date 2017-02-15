using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpriteFlipperParent : MonoBehaviour 
{
	public bool addChildren = true;
	public bool facingRight = false;
	private Rigidbody2D body;

	private List<SpriteFlipperChild> flippers;

	// Use this for initialization
	void Awake () 
	{
		body = GetComponent<Rigidbody2D> ();
		flippers = new List<SpriteFlipperChild> ();
			if (addChildren)
			{
			flippers.AddRange (GetComponentsInChildren<SpriteFlipperChild> ());
			}
	}

	void Start ()
	{
		UpdateChildren ();
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
			UpdateChildren ();
		}
		else if (body.velocity.x < 0 && (facingRight == true || force))
		{
			facingRight = false;
			UpdateChildren ();
		}
	}

	void UpdateChildren()
	{
		for (int i = 0; i < flippers.Count; i++) 
		{
			flippers [i].Flip (facingRight);
		}
	}

	void AddChild (SpriteFlipperChild child)
	{
		if (!flippers.Contains (child))
		{
			flippers.Add (child);
		}
	}

	void RemoveChild (SpriteFlipperChild child)
	{
		if (flippers.Contains (child))
		{
			flippers.Remove (child);
		}
	}
}
