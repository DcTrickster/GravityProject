using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Movement : MonoBehaviour 
{
	Rigidbody2D body;
	public KeyCode RightKey;
	public KeyCode LeftKey;
	public KeyCode JumpKey;
	public KeyCode ShootKey;
	public KeyCode PauseKey;

	public KeyCode FlipKeyUp;
	public KeyCode FlipKeyDown;
	public KeyCode FlipKeyLeft;
	public KeyCode FlipKeyRight;


	public float moveSpeed;

	public float Gravity = 9f;

//	public float jumpForce;
//	public bool isGrounded;
//	float groundCheckRadius = 0.2f;
//	public LayerMask ground;

	public GameObject Bullet;
	public GameObject Bullet2;
	public int shootSpeed = 50;
	public bool recharging = false;

	bool isFacingRight;

	public string playerId;
	public string teamId;
	public string joystickNumber;

	public bool isPaused;

	private bool Upways;
	private bool Sideways;

	public float moveHor;
	public float moveVer;

	void Start()
	{

	
		Upways = true;
		Sideways = false;
		body = transform.GetComponent<Rigidbody2D>();
		isFacingRight = true;
		joystickNumber = gameObject.GetComponent<Movement> ().playerId.ToString ();
//		isPaused = gameObject.GetComponent<PauseMenu> ().isPaused;
	}

	void Update ()
	{
		TestfacingRight ();
	}

	void TestfacingRight (bool force = false)
	{
		if (body.velocity.x > 0 && (isFacingRight == false || force)) 
		{
			isFacingRight = true;
		}
		else if (body.velocity.x < 0 && (isFacingRight == true || force))
		{
			isFacingRight = false;
		}
	}

	void FixedUpdate()
	{

			moveHor = Input.GetAxisRaw ("PlayerLeftJoystickHor" + joystickNumber);
			moveVer = Input.GetAxisRaw ("PlayerLeftJoystickVert" + joystickNumber);
			body.AddForce (transform.up * -Gravity);




//		isGrounded = Physics2D.OverlapCircle (transform.position, groundCheckRadius, ground);

		if (gameObject.GetComponent<Respawn>().Respawning == false)
		{
			if (Upways == true)
			{
			body.velocity = new Vector2 (moveHor * moveSpeed, body.velocity.y);
			}
			if (Sideways == true)
			{
			body.velocity = new Vector2 (body.velocity.x, moveVer * moveSpeed);
			}

			//CODE TO SHOOT & RECHARGE
			if (Input.GetKeyDown (ShootKey)) 
			{
				if (this.gameObject.tag == "Team1") 
				{
					if (moveVer == 1 && Upways == true) {
						GameObject bulletClone = GameObject.Instantiate (Bullet, this.transform.position, Quaternion.Euler (new Vector3 (0, 0, 1))) as GameObject;
						bulletClone.GetComponent<Rigidbody2D> ().AddForce (transform.up * shootSpeed);
//					Physics2D.IgnoreCollision (bulletClone.GetComponent<Collider2D> (), GetComponent<Collider2D> ());
						StartCoroutine (recharching ());
					}

					if (moveVer == -1 && Upways == true) {
						GameObject bulletClone = GameObject.Instantiate (Bullet, this.transform.position, Quaternion.Euler (new Vector3 (0, 0, 1))) as GameObject;
						bulletClone.GetComponent<Rigidbody2D> ().AddForce (-transform.up * shootSpeed);
//					Physics2D.IgnoreCollision (bulletClone.GetComponent<Collider2D> (), GetComponent<Collider2D> ());
						StartCoroutine (recharching ());
					}

					if (moveHor == 1 && Sideways == true) {
						GameObject bulletClone = GameObject.Instantiate (Bullet, this.transform.position, Quaternion.Euler (new Vector3 (0, 0, 1))) as GameObject;
						bulletClone.GetComponent<Rigidbody2D> ().AddForce (transform.up * shootSpeed);
//					Physics2D.IgnoreCollision (bulletClone.GetComponent<Collider2D> (), GetComponent<Collider2D> ());
						StartCoroutine (recharching ());
					}

					if (moveHor == -1 && Sideways == true) {
						GameObject bulletClone = GameObject.Instantiate (Bullet, this.transform.position, Quaternion.Euler (new Vector3 (0, 0, 1))) as GameObject;
						bulletClone.GetComponent<Rigidbody2D> ().AddForce (-transform.up * shootSpeed);
//					Physics2D.IgnoreCollision (bulletClone.GetComponent<Collider2D> (), GetComponent<Collider2D> ());
						StartCoroutine (recharching ());
					}

					if (isFacingRight == true) {
						if (recharging == false) {
							GameObject bulletClone = GameObject.Instantiate (Bullet, this.transform.position, Quaternion.Euler (new Vector3 (0, 0, 1))) as GameObject;
							bulletClone.GetComponent<Rigidbody2D> ().AddForce (transform.right * shootSpeed);
//						Physics2D.IgnoreCollision (bulletClone.GetComponent<Collider2D> (), GetComponent<Collider2D> ());
							StartCoroutine (recharching ());
						}
					}

					if (isFacingRight != true) {
						if (recharging == false) {
							GameObject bulletClone = GameObject.Instantiate (Bullet, this.transform.position, Quaternion.Euler (new Vector3 (0, 0, 1))) as GameObject;
							bulletClone.GetComponent<Rigidbody2D> ().AddForce (-(transform.right * shootSpeed));
//						Physics2D.IgnoreCollision (bulletClone.GetComponent<Collider2D> (), GetComponent<Collider2D> ());
							StartCoroutine (recharching ());
						}
					}
				}

				if (this.gameObject.tag == "Team2") 
				{
					if (moveVer == 1 && Upways == true) {
						GameObject bulletClone = GameObject.Instantiate (Bullet2, this.transform.position, Quaternion.Euler (new Vector3 (0, 0, 1))) as GameObject;
						bulletClone.GetComponent<Rigidbody2D> ().AddForce (transform.up * shootSpeed);
						//					Physics2D.IgnoreCollision (bulletClone.GetComponent<Collider2D> (), GetComponent<Collider2D> ());
						StartCoroutine (recharching ());
					}

					if (moveVer == -1 && Upways == true) {
						GameObject bulletClone = GameObject.Instantiate (Bullet2, this.transform.position, Quaternion.Euler (new Vector3 (0, 0, 1))) as GameObject;
						bulletClone.GetComponent<Rigidbody2D> ().AddForce (-transform.up * shootSpeed);
						//					Physics2D.IgnoreCollision (bulletClone.GetComponent<Collider2D> (), GetComponent<Collider2D> ());
						StartCoroutine (recharching ());
					}

					if (moveHor == 1 && Sideways == true) {
						GameObject bulletClone = GameObject.Instantiate (Bullet2, this.transform.position, Quaternion.Euler (new Vector3 (0, 0, 1))) as GameObject;
						bulletClone.GetComponent<Rigidbody2D> ().AddForce (transform.up * shootSpeed);
						//					Physics2D.IgnoreCollision (bulletClone.GetComponent<Collider2D> (), GetComponent<Collider2D> ());
						StartCoroutine (recharching ());
					}

					if (moveHor == -1 && Sideways == true) {
						GameObject bulletClone = GameObject.Instantiate (Bullet2, this.transform.position, Quaternion.Euler (new Vector3 (0, 0, 1))) as GameObject;
						bulletClone.GetComponent<Rigidbody2D> ().AddForce (-transform.up * shootSpeed);
						//					Physics2D.IgnoreCollision (bulletClone.GetComponent<Collider2D> (), GetComponent<Collider2D> ());
						StartCoroutine (recharching ());
					}

					if (isFacingRight == true) {
						if (recharging == false) {
							GameObject bulletClone = GameObject.Instantiate (Bullet2, this.transform.position, Quaternion.Euler (new Vector3 (0, 0, 1))) as GameObject;
							bulletClone.GetComponent<Rigidbody2D> ().AddForce (transform.right * shootSpeed);
							//						Physics2D.IgnoreCollision (bulletClone.GetComponent<Collider2D> (), GetComponent<Collider2D> ());
							StartCoroutine (recharching ());
						}
					}

					if (isFacingRight != true) {
						if (recharging == false) {
							GameObject bulletClone = GameObject.Instantiate (Bullet2, this.transform.position, Quaternion.Euler (new Vector3 (0, 0, 1))) as GameObject;
							bulletClone.GetComponent<Rigidbody2D> ().AddForce (-(transform.right * shootSpeed));
							//						Physics2D.IgnoreCollision (bulletClone.GetComponent<Collider2D> (), GetComponent<Collider2D> ());
							StartCoroutine (recharching ());
						}
					}
				}
			}
		}


		//CHANGING THE ROTATION OF THE PLAYER
		Quaternion up = Quaternion.Euler(0,0,180);
		Quaternion down = Quaternion.Euler(0,0,0);
		Quaternion right = Quaternion.Euler(0,0,90);
		Quaternion left = Quaternion.Euler(0,0,270);

		//CODE TO JUMP
//		if (isGrounded && Input.GetKeyDown (JumpKey)) 
//		{
//			body.AddForce (new Vector2(0, jumpForce));
//		}


		//CODE TO FLIP THE GRAVITY OF THE PLAYER
		if (Input.GetKeyDown (FlipKeyUp))
		{
			transform.rotation = up;
//			body.AddForce (transform.up * -Gravity);
//			Physics2D.gravity = new Vector2 (1f,9.8f);
			Upways = true;
			Sideways = false;
		}

		if (Input.GetKeyDown (FlipKeyDown))
		{
			transform.rotation = down;
//			Physics2D.gravity = new Vector2 (1f,-9.8f);
//			body.AddForce (transform.up * Gravity);

			Upways = true;
			Sideways = false;
		}

		if (Input.GetKeyDown (FlipKeyRight))
		{
			transform.rotation = right;
//			Physics2D.gravity = new Vector2 (200f,0f);
//			body.AddForce (transform.up * Gravity);

			Upways = false;
			Sideways = true;
		}

		if (Input.GetKeyDown (FlipKeyLeft))
		{
			transform.rotation = left;
//			Physics2D.gravity = new Vector2 (-200f,0f);
//			body.AddForce (transform.up * Gravity);

			Upways = false;
			Sideways = true;
		}
	}

	public IEnumerator recharching()
	{
		recharging = true;
		print ("Recharging is " + recharging);
		yield return new WaitForSeconds (0.5f);
		recharging = false;
		print ("Recharging is " + recharging);
	}
}
