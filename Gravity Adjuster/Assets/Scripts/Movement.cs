using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Movement : MonoBehaviour 
{
	//Key Inputs to move
	Rigidbody2D body;
	public KeyCode RightKey;
	public KeyCode LeftKey;
	public KeyCode JumpKey;
	public KeyCode ShootKey;
	public KeyCode ThrowKey;
	public KeyCode PauseKey;

	//Key Inputs to flip
	public KeyCode FlipKeyUp;
	public KeyCode FlipKeyDown;
	public KeyCode FlipKeyLeft;
	public KeyCode FlipKeyRight;

	public Animator anim;

	//Audio
	AudioSource Sounds;
	public AudioClip[] gunSounds;
	public AudioClip[] rechargeSounds;

	//Variable to flip sprite
	public SpriteRenderer mySpriteRendererTop;
	public SpriteRenderer mySpriteRendererBot;
	public bool facingRight = false;
	bool isFacingRight;


	public float moveSpeed;

	public float Gravity = 9f;

	//Variables for weapons
	public GameObject Bullet;
	public GameObject Bullet2;
	public GameObject Grenade1;
	public GameObject Grenade2;
	public int shootSpeed = 50;
	public int throwSpeed = 200;
	public bool recharging = false;

	public bool grenadePickUp;
	public int grenades;

	public bool laserBeam;
	public GameObject laser;
	int laserLength;

	public bool flameThrower;
	public GameObject Fire;


	//Variables for Controllers
	public string playerId;
	public string teamId;
	public string joystickNumber;

	float deadzone = 0.25f;

	public bool isPaused;

	//Variables for current facing direction
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

		mySpriteRendererTop = GetComponent<SpriteRenderer> ();
		mySpriteRendererBot = GetComponent<SpriteRenderer> ();

		Sounds = gameObject.GetComponent<AudioSource> ();

		grenades = 1;
		laserBeam = false;
		flameThrower = false;
	}

	void Update ()
	{
//		Debug.DrawRay (this.transform.position, transform.right, Color.red);
		Testflipping ();
	}

	//How to make the sprite flip
	void Testflipping (bool force = false)
	{
		if (facingUp == true)
		{
			Debug.Log ("Facing Up");
			if (body.velocity.x > 0 && (isFacingRight == false)) {
				isFacingRight = true;
				mySpriteRendererTop.flipX = false;
				mySpriteRendererBot.flipX = false;
				anim.SetBool ("PointUp", true);

			} 
			else if (body.velocity.x < 0 && (isFacingRight == true)) 
			{
				isFacingRight = false;
				mySpriteRendererTop.flipX = true;
				mySpriteRendererBot.flipX = true;
				anim.SetBool ("PointUp", true);

			}
		}

		if (facingDown == true)
		{
			Debug.Log ("Facing down");
			if (body.velocity.x < 0 && (isFacingRight == false)) {
				isFacingRight = true;
				mySpriteRendererTop.flipX = false;
				mySpriteRendererBot.flipX = false;

			} 
			else if (body.velocity.x > 0 && (isFacingRight == true)) 
			{
				isFacingRight = false;
				mySpriteRendererTop.flipX = true;
				mySpriteRendererBot.flipX = true;

			}
		}
	}

	void FixedUpdate()
	{

			moveHor = Input.GetAxisRaw ("PlayerLeftJoystickHor" + joystickNumber);
			moveVer = Input.GetAxisRaw ("PlayerLeftJoystickVert" + joystickNumber);
			body.AddForce (transform.up * -Gravity);

		Vector2 stickInput = new Vector2 (moveHor, moveVer);
		if (Mathf.Abs (stickInput.x) < deadzone)
			stickInput.x = 0.0f;
		if (Mathf.Abs (stickInput.y) < deadzone)
			stickInput.y = 0.0f;

		int randomShoot = Random.Range(0, gunSounds.Length);



		//How to move on walls, floor and roof
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
					//Shoot Up On floor/Roof
					if (moveVer == 1 && Upways == true) {
						if (recharging == false) {
							Sounds.PlayOneShot (gunSounds [randomShoot]);
							GameObject bulletClone = GameObject.Instantiate (Bullet, this.transform.position, Quaternion.Euler (new Vector3 (0, 0, 1))) as GameObject;
							bulletClone.GetComponent<Rigidbody2D> ().AddForce (transform.up * shootSpeed);
							StartCoroutine (recharching ());
						}
					}
					//Shoot Down On floor/Roof
					if (moveVer == -1 && Upways == true) {
						if (recharging == false)
						{
						Sounds.PlayOneShot (gunSounds [randomShoot]);
						GameObject bulletClone = GameObject.Instantiate (Bullet, this.transform.position, Quaternion.Euler (new Vector3 (0, 0, 1))) as GameObject;
						bulletClone.GetComponent<Rigidbody2D> ().AddForce (-transform.up * shootSpeed);
						StartCoroutine (recharching ());
						}
					}
					//Shoot Up On Wall
					if (moveHor == 1 && Sideways == true) {
						if (recharging == false) {
							Sounds.PlayOneShot (gunSounds [randomShoot]);
							GameObject bulletClone = GameObject.Instantiate (Bullet, this.transform.position, Quaternion.Euler (new Vector3 (0, 0, 1))) as GameObject;
							bulletClone.GetComponent<Rigidbody2D> ().AddForce (transform.up * shootSpeed);
							StartCoroutine (recharching ());
						}
					}
					//Shot Down On Wall
					if (moveHor == -1 && Sideways == true) {
						if (recharging == false) {
							Sounds.PlayOneShot (gunSounds [randomShoot]);
							GameObject bulletClone = GameObject.Instantiate (Bullet, this.transform.position, Quaternion.Euler (new Vector3 (0, 0, 1))) as GameObject;
							bulletClone.GetComponent<Rigidbody2D> ().AddForce (-transform.up * shootSpeed);
							StartCoroutine (recharching ());
						}
					}
					//Shoot Right
					if (isFacingRight == true) {
						if (recharging == false) {
							Sounds.PlayOneShot (gunSounds [randomShoot]);
							GameObject bulletClone = GameObject.Instantiate (Bullet, this.transform.position, Quaternion.Euler (new Vector3 (0, 0, 1))) as GameObject;
							bulletClone.GetComponent<Rigidbody2D> ().AddForce (transform.right * shootSpeed);
							StartCoroutine (recharching ());
						}
					}
					//Shoot Left
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
						if (recharging == false)
						{
						Sounds.PlayOneShot (gunSounds [randomShoot]);
						GameObject bulletClone = GameObject.Instantiate (Bullet2, this.transform.position, Quaternion.Euler (new Vector3 (0, 0, 1))) as GameObject;
						bulletClone.GetComponent<Rigidbody2D> ().AddForce (transform.up * shootSpeed);
						StartCoroutine (recharching ());
						}
					}

					if (moveVer == -1 && Upways == true) {
						if (recharging == false)
						{
						Sounds.PlayOneShot (gunSounds [randomShoot]);
						GameObject bulletClone = GameObject.Instantiate (Bullet2, this.transform.position, Quaternion.Euler (new Vector3 (0, 0, 1))) as GameObject;
						bulletClone.GetComponent<Rigidbody2D> ().AddForce (-transform.up * shootSpeed);
						StartCoroutine (recharching ());
						}
					}

					if (moveHor == 1 && Sideways == true) {
						if (recharging == false)
						{
						Sounds.PlayOneShot (gunSounds [randomShoot]);
						GameObject bulletClone = GameObject.Instantiate (Bullet2, this.transform.position, Quaternion.Euler (new Vector3 (0, 0, 1))) as GameObject;
						bulletClone.GetComponent<Rigidbody2D> ().AddForce (transform.up * shootSpeed);
						StartCoroutine (recharching ());
						}
					}

					if (moveHor == -1 && Sideways == true) {
						if (recharging == false)
						{
						Sounds.PlayOneShot (gunSounds [randomShoot]);
						GameObject bulletClone = GameObject.Instantiate (Bullet2, this.transform.position, Quaternion.Euler (new Vector3 (0, 0, 1))) as GameObject;
						bulletClone.GetComponent<Rigidbody2D> ().AddForce (-transform.up * shootSpeed);
						StartCoroutine (recharching ());
						}
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

					if (this.gameObject.tag == "Team1") {
						if (isFacingRight == true) {
							GameObject grenadeClone = GameObject.Instantiate (Grenade1, this.transform.position, Quaternion.Euler (new Vector3 (0, 1, 2))) as GameObject;
								grenadeClone.GetComponent<Rigidbody2D> ().AddForce (transform.right * throwSpeed);
							grenades--;
						}

						if (isFacingRight != true) {
								GameObject grenadeClone = GameObject.Instantiate (Grenade1, this.transform.position, Quaternion.Euler (new Vector3 (0, -1, 2))) as GameObject;
								grenadeClone.GetComponent<Rigidbody2D> ().AddForce (-(transform.right * throwSpeed));
							grenades--;
						}
					}

					if (this.gameObject.tag == "Team2") {
						if (isFacingRight == true) {
							GameObject grenadeClone = GameObject.Instantiate (Grenade2, this.transform.position, Quaternion.Euler (new Vector3 (0, 0, 1))) as GameObject;
							grenadeClone.GetComponent<Rigidbody2D> ().AddForce (transform.right * throwSpeed);
							grenades--;
						}

						if (isFacingRight != true) {
							GameObject grenadeClone = GameObject.Instantiate (Grenade2, this.transform.position, Quaternion.Euler (new Vector3 (0, 0, 1))) as GameObject;
							grenadeClone.GetComponent<Rigidbody2D> ().AddForce (-(transform.right * throwSpeed));
							grenades--;
						}
					}
				}
			}
		}

		//LASERBEAM
		if (laserBeam == true) {
			print ("You have the laserbeam!");
			//		if (Input.GetKeyDown (ShootKey) && laserBeam == true)
			//	{
			GameObject laserClone = Instantiate (laser, this.transform.position + new Vector3 (laser.transform.localScale.x + (this.transform.localScale.x/2), 0, 0), Quaternion.Euler (new Vector3 (0, 0, 1)), this.gameObject.transform) as GameObject;
			laserClone.transform.SetParent (gameObject.transform);
			laserBeam = false;

		}

		//FLAMETHROWER
		if (flameThrower == true) 
		{
			print ("You have the FlameThrower!");
			if (Input.GetKeyDown (ShootKey) && flameThrower == true)
			{
//				GameObject flameClone = Instantiate (flameThrower, this.transform.position, new Vector3 (this.transform.position * 2,0,0), Quaternion.Euler (new Vector3 (0, 0, 1)), this.gameObject.transform) as GameObject;
				//MAKE FLAME FOR 8 SECONDS, WILL FOLLOW PLAYER
			}
			flameThrower = false;
		}

		//GRENADE
		if (grenadePickUp == true) 
		{
			print ("You got a grenade!");
			grenades++;
			grenadePickUp = false;
		}

		//CHANGING THE ROTATION OF THE PLAYER
		Quaternion up = Quaternion.Euler(0,0,180);
		Quaternion down = Quaternion.Euler(0,0,0);
		Quaternion right = Quaternion.Euler(0,0,90);
		Quaternion left = Quaternion.Euler(0,0,270);


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
