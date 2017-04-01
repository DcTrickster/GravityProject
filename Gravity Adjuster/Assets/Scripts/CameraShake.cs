using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour {

	public static float ShakeAmount = 0f;

	public bool shaking = false;
	public float shakeDecay = 0.8f;
	Vector3 originPos;
	Quaternion originRot;

	// Use this for initialization
	void Start () {
		originPos = gameObject.transform.position;
		originRot = gameObject.transform.localRotation;
		if (shaking == true) {
			ShakeAmount = 10f;
		}
	}

	// Update is called once per frame
	void Update () {
		if (ShakeAmount > 0) {
			Vector3 moveAmount = Random.insideUnitCircle * ShakeAmount;
			moveAmount.z = 0;
			ShakeAmount = Mathf.Lerp (ShakeAmount, 0, shakeDecay);
		//	ShakeAmount -= shakeDecay;
			transform.position = moveAmount;
		} else {
			gameObject.transform.position = originPos;
		}
	}
}
