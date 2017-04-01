using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade : MonoBehaviour {

	private int detonationTime;
	CircleCollider2D col;
	Rigidbody2D RB;
	SpriteRenderer SR;
	public Sprite explosion;
	bool detonate;

	// Use this for initialization
	void Start () {
		detonationTime = 3;
		detonate = false;
		col = gameObject.GetComponent<CircleCollider2D>();
		RB = gameObject.GetComponent<Rigidbody2D> ();
		SR = gameObject.GetComponent<SpriteRenderer> ();
		Invoke ("Boom", detonationTime);
	}
	
	// Update is called once per frame
	void Update () {
		if (detonate) { 
			col.isTrigger = true;
			RB.constraints = RigidbodyConstraints2D.FreezePosition;
			SR.sprite = explosion;
			col.radius += 0.25f;
			if (col.radius > 5f) {
				Destroy (this.gameObject);
			}
		}
	}

	void Boom() {
		detonate = true;
	}
		
}
