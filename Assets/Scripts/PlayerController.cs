using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public float moveSpeed;
	public float jumpForce;
	public float speedBooster;

	public float speedBoosterMiles;

	private float speedMilesCount;
	private Rigidbody2D catBody;
	public Transform groundCheck;
	public float groundCheckRadius;
	public float jumpTime;
	private float jumpTimeCounter; 
	public bool grounded;
	public LayerMask whatIsGround;
	private Collider2D collider;
	private Animator animator;
	private bool stoppedJumping;
	public AudioSource deathSound;


	public GameManager theGameManager;
	// Use this for initialization
	void Start () {
		catBody = GetComponent<Rigidbody2D> ();
		collider = GetComponent<Collider2D> ();
		animator = GetComponent<Animator> ();
		jumpTimeCounter = jumpTime;
		speedMilesCount = speedBoosterMiles;
		stoppedJumping = true;
	}

	// Update is called once per frame
	void Update () {

		grounded = Physics2D.IsTouchingLayers (collider, whatIsGround);
		//grounded = Physics2D.OverlapCircle(groundCheck.position,groundCheckRadius,whatIsGround);


		if (transform.position.x > speedMilesCount) {
			
			speedMilesCount += speedBoosterMiles;

			speedBoosterMiles = speedBoosterMiles * speedBooster;

			moveSpeed = moveSpeed * speedBooster;
		}

		catBody.velocity = new Vector2 (moveSpeed, catBody.velocity.y);

		//jump key
		if (Input.GetKeyDown (KeyCode.Space)) {
			if (grounded) {
				catBody.velocity = new Vector2 (catBody.velocity.x, jumpForce);	
				stoppedJumping = false;
			}
		}
		if (Input.GetKey (KeyCode.Space) && !stoppedJumping) {
			if (jumpTimeCounter > 0) {
				catBody.velocity = new Vector2 (catBody.velocity.x, jumpForce);
				jumpTimeCounter -= Time.deltaTime;
			}
		}
		if(Input.GetKeyUp(KeyCode.Space)){
			jumpTimeCounter = 0;
			stoppedJumping = true;
		}
		if(grounded){
			jumpTimeCounter = jumpTime;
		}
		//animation triggers

		animator.SetBool ("Grounded", grounded);
	}
	void OnCollisionEnter2D (Collision2D other)
	{
		if(other.gameObject.tag == "killbox")
			{
				theGameManager.RestartGame();
			deathSound.Play ();

			}
	}
}
