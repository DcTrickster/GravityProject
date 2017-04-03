using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class laserBeam : MonoBehaviour {
	float laserLength;
	Vector2 wallPos;
	Vector3 startScale;
	// Use this for initialization
	void Start () {
		Destroy (this.gameObject, 3f);
		startScale = this.gameObject.transform.localScale;
	}
	
	// Update is called once per frame
	void Update () {
	//	transform.position = transform.parent.position + new Vector3(this.transform.localScale.x + (this.transform.localScale.x/2), 0, 0);
		transform.localPosition = Vector3.zero + new Vector3(this.transform.localScale.x, 0, 0);
		RaycastHit2D hit;
		hit = Physics2D.Raycast (this.transform.position, transform.right);
//		int i = 0;
//		while (i < hit.Length) {
			if (hit == GameObject.FindWithTag ("Obstacle")) {
			print ("hitting wall");
			wallPos = hit.transform.position;
			//	laserLength = (int)Mathf.Round (hit.distance);
			laserLength = Mathf.Abs(transform.parent.position.x - wallPos.x);
			Vector3 newScale = startScale;
			newScale.x = (gameObject.transform.localScale.x) + laserLength/2;
			gameObject.transform.localScale = newScale;
			}
//			i++;
		}

	}
