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
	public KeyCode ThrowKey;
	public KeyCode PauseKey;

	public KeyCode FlipKeyUp;
	public KeyCode FlipKeyDown;
	public KeyCode FlipKeyLeft;
	public KeyCode FlipKeyRight;

	public Animator anim;

	AudioSource Sounds;
	public AudioClip[] gunSounds;
	public AudioClip[] rechargeSounds;

	public SpriteRenderer mySpriteRenderer;
	public bool facingRight = false;


	public float moveSpeed;

	public float Gravity = 9f;

//	public float jumpForce;
//	public bool isGrounded;
//	float groundCheckRadius = 0.2f;
//	public LayerMask ground;

	public GameObject Bullet;
	public GameObject Bullet2;
	public GameObject Grenade1;
	public GameObject Grenade2;
	public int shootSpeed = 50;
	public int throwSpeed = 200;
	public bool recharging = false;
	public int grenades;

	bool isFacingRight;

	public string playerId;
	public string teamId;
	public string joystickNumber;

	public bool isPaused;

	private bool Upways;
	private bool Sideways;
	private bool facingUp;
	private bool facingDown;

	public float moveHor;
	public float moveVer;


	void Start()
	{

		facingUp = true;
		Upways = true;
		Sideways = false;
		body = transform.GetComponent<Rigidbody2D>();
		isFacingRight = true;
		joystickNumber = gameObject.GetComponent<Movement> ().playerId.ToString ();

		mySpriteRenderer = GetComponent<SpriteRenderer> ();

		Sounds = gameObject.GetComponent<AudioSource> ();

		grenades = 1;
	}

	void Update ()
	{
		Testflipping ();
	}

	void Testflipping (bool force = false)
	{
		if (facingUp == true)
		{
			Debug.Log ("Facing Up");
			if (body.velocity.x > 0 && (isFacingRight == false)) {
				isFacingRight = true;
				mySpriteRenderer.flipX = false;
				anim.SetBool ("PointUp", true);

			} 
			else if (body.velocity.x < 0 && (isFacingRight == true)) 
			{
				isFacingRight = false;
				mySpriteRenderer.flipX = true;
				anim.SetBool ("PointUp", true);

			}
		}

		if (facingDown == true)
		{
			Debug.Log ("Facing down");
			if (body.velocity.x < 0 && (isFacingRight == false)) {
				isFacingRight = true;
				mySpriteRenderer.flipX = false;

			} 
			else if (body.velocity.x > 0 && (isFacingRight == true)) 
			{
				isFacingRight = false;
				mySpriteRenderer.flipX = true;

			}
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

			//THROW GRENADES
			if (grenades > 0) {
				if (Input.GetKeyUp (ThrowKey)) {
					//Sounds.PlayOneShot (gunSounds [randomShoot]);

					if (this.gameObject.tag == "Team1") {
						if (isFacingRight == true) {
							GameObject grenadeClone = GameObject.Instantiate (Grenade1, this.transform.position, Quaternion.Euler (new Vector3 (0, 1, 2))) as GameObject;
								grenadeClone.GetComponent<Rigidbody2D> ().AddForce (transform.right * throwSpeed);
							grenades--;
						//	grenadeClone.GetComponent<Grenade> ().detonationTime = 3;
						}

						if (isFacingRight != true) {
								GameObject grenadeClone = GameObject.Instantiate (Grenade1, this.transform.position, Quaternion.Euler (new Vector3 (0, -1, 2))) as GameObject;
								grenadeClone.GetComponent<Rigidbody2D> ().AddForce (-(transform.right * throwSpeed));
							grenades--;
						//	grenadeClone.GetComponent<Grenade> ().detonationTime = 3;
						}
					}

					if (this.gameObject.tag == "Team2") {
						if (isFacingRight == true) {
							GameObject grenadeClone = GameObject.Instantiate (Grenade2, this.transform.position, Quaternion.Euler (new Vector3 (0, 0, 1))) as GameObject;
							grenadeClone.GetComponent<Rigidbody2D> ().AddForce (transform.right * throwSpeed);
							grenades--;
						//	grenadeClone.GetComponent<Grenade> ().detonationTime = 3;
						}

						if (isFacingRight != true) {
							GameObject grenadeClone = GameObject.Instantiate (Grenade2, this.transform.position, Quaternion.Euler (new Vector3 (0, 0, 1))) as GameObject;
							grenadeClone.GetComponent<Rigidbody2D> ().AddForce (-(transform.right * throwSpeed));
							grenades--;
						//	grenadeClone.GetComponent<Grenade> ().detonationTime = 3;
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
			facingUp = false;
			facingDown = true;
		}

		if (Input.GetKeyDown (FlipKeyDown))
		{
			transform.rotation = down;
			Upways = true;
			Sideways = false;
			facingUp = true;
			facingDown = false;
		}

		if (Input.GetKeyDown (FlipKeyRight))
		{
			transform.rotation = right;
			Upways = false;
			Sideways = true;
			facingUp = false;
			facingDown = true;
		}

		if (Input.GetKeyDown (FlipKeyLeft))
		{
			transform.rotation = left;
			Upways = false;
			Sideways = true;
			facingUp = true;
			facingDown = false;
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
