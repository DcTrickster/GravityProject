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

	AudioSource Sounds;
	public AudioClip[] gunSounds;
	public AudioClip[] rechargeSounds;



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

		Sounds = gameObject.GetComponent<AudioSource> ();
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

		int randomShoot = Random.Range(0, gunSounds.Length);



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
						Sounds.PlayOneShot (gunSounds [randomShoot]);
						GameObject bulletClone = GameObject.Instantiate (Bullet, this.transform.position, Quaternion.Euler (new Vector3 (0, 0, 1))) as GameObject;
						bulletClone.GetComponent<Rigidbody2D> ().AddForce (transform.up * shootSpeed);
						StartCoroutine (recharching ());
					}

					if (moveVer == -1 && Upways == true) {
						Sounds.PlayOneShot (gunSounds [randomShoot]);
						GameObject bulletClone = GameObject.Instantiate (Bullet, this.transform.position, Quaternion.Euler (new Vector3 (0, 0, 1))) as GameObject;
						bulletClone.GetComponent<Rigidbody2D> ().AddForce (-transform.up * shootSpeed);
						StartCoroutine (recharching ());
					}

					if (moveHor == 1 && Sideways == true) {
						Sounds.PlayOneShot (gunSounds [randomShoot]);
						GameObject bulletClone = GameObject.Instantiate (Bullet, this.transform.position, Quaternion.Euler (new Vector3 (0, 0, 1))) as GameObject;
						bulletClone.GetComponent<Rigidbody2D> ().AddForce (transform.up * shootSpeed);
						StartCoroutine (recharching ());
					}

					if (moveHor == -1 && Sideways == true) {
						Sounds.PlayOneShot (gunSounds [randomShoot]);
						GameObject bulletClone = GameObject.Instantiate (Bullet, this.transform.position, Quaternion.Euler (new Vector3 (0, 0, 1))) as GameObject;
						bulletClone.GetComponent<Rigidbody2D> ().AddForce (-transform.up * shootSpeed);
						StartCoroutine (recharching ());
					}

					if (isFacingRight == true) {
						if (recharging == false) {
							Sounds.PlayOneShot (gunSounds [randomShoot]);
							GameObject bulletClone = GameObject.Instantiate (Bullet, this.transform.position, Quaternion.Euler (new Vector3 (0, 0, 1))) as GameObject;
							bulletClone.GetComponent<Rigidbody2D> ().AddForce (transform.right * shootSpeed);
							StartCoroutine (recharching ());
						}
					}

					if (isFacingRight != true) {
						if (recharging == false) {
							Sounds.PlayOneShot (gunSounds [randomShoot]);
							GameObject bulletClone = GameObject.Instantiate (Bullet, this.transform.position, Quaternion.Euler (new Vector3 (0, 0, 1))) as GameObject;
							bulletClone.GetComponent<Rigidbody2D> ().AddForce (-(transform.right * shootSpeed));
							StartCoroutine (recharching ());
						}
					}
				}

				if (this.gameObject.tag == "Team2") 
				{
					if (moveVer == 1 && Upways == true) {
						Sounds.PlayOneShot (gunSounds [randomShoot]);
						GameObject bulletClone = GameObject.Instantiate (Bullet2, this.transform.position, Quaternion.Euler (new Vector3 (0, 0, 1))) as GameObject;
						bulletClone.GetComponent<Rigidbody2D> ().AddForce (transform.up * shootSpeed);
						StartCoroutine (recharching ());
					}

					if (moveVer == -1 && Upways == true) {
						Sounds.PlayOneShot (gunSounds [randomShoot]);
						GameObject bulletClone = GameObject.Instantiate (Bullet2, this.transform.position, Quaternion.Euler (new Vector3 (0, 0, 1))) as GameObject;
						bulletClone.GetComponent<Rigidbody2D> ().AddForce (-transform.up * shootSpeed);
						StartCoroutine (recharching ());
					}

					if (moveHor == 1 && Sideways == true) {
						Sounds.PlayOneShot (gunSounds [randomShoot]);
						GameObject bulletClone = GameObject.Instantiate (Bullet2, this.transform.position, Quaternion.Euler (new Vector3 (0, 0, 1))) as GameObject;
						bulletClone.GetComponent<Rigidbody2D> ().AddForce (transform.up * shootSpeed);
						StartCoroutine (recharching ());
					}

					if (moveHor == -1 && Sideways == true) {
						Sounds.PlayOneShot (gunSounds [randomShoot]);
						GameObject bulletClone = GameObject.Instantiate (Bullet2, this.transform.position, Quaternion.Euler (new Vector3 (0, 0, 1))) as GameObject;
						bulletClone.GetComponent<Rigidbody2D> ().AddForce (-transform.up * shootSpeed);
						StartCoroutine (recharching ());
					}

					if (isFacingRight == true) {
						if (recharging == false) {
							Sounds.PlayOneShot (gunSounds [randomShoot]);
							GameObject bulletClone = GameObject.Instantiate (Bullet2, this.transform.position, Quaternion.Euler (new Vector3 (0, 0, 1))) as GameObject;
							bulletClone.GetComponent<Rigidbody2D> ().AddForce (transform.right * shootSpeed);
							StartCoroutine (recharching ());
						}
					}

					if (isFacingRight != true) {
						if (recharging == false) {				
							Sounds.PlayOneShot (gunSounds [randomShoot]);
							GameObject bulletClone = GameObject.Instantiate (Bullet2, this.transform.position, Quaternion.Euler (new Vector3 (0, 0, 1))) as GameObject;
							bulletClone.GetComponent<Rigidbody2D> ().AddForce (-(transform.right * shootSpeed));
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
			Upways = true;
			Sideways = false;
		}

		if (Input.GetKeyDown (FlipKeyDown))
		{
			transform.rotation = down;
			Upways = true;
			Sideways = false;
		}

		if (Input.GetKeyDown (FlipKeyRight))
		{
			transform.rotation = right;
			Upways = false;
			Sideways = true;
		}

		if (Input.GetKeyDown (FlipKeyLeft))
		{
			transform.rotation = left;
			Upways = false;
			Sideways = true;
		}
	}

	public IEnumerator recharching()
	{
		int randomCharge = Random.Range(0, rechargeSounds.Length);

		recharging = true;
		print ("Recharging is " + recharging);
		Sounds.PlayOneShot (rechargeSounds [randomCharge]);
		yield return new WaitForSeconds (1f);
		recharging = false;
		print ("Recharging is " + recharging);
	}
}
