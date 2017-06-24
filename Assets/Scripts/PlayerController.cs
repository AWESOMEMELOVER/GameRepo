using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public float moveSpeed;
	public float jumpForce;

	private Rigidbody2D catBody;

	public bool grounded;
	public LayerMask whatIsGround;
	private Collider2D collider;
	private Animator animator;

	public GameManeger theGameManeger;
	// Use this for initialization
	void Start () {
		catBody = GetComponent<Rigidbody2D> ();
		collider = GetComponent<Collider2D> ();
		animator = GetComponent<Animator> ();
	}

	// Update is called once per frame
	void Update () {

		grounded = Physics2D.IsTouchingLayers (collider, whatIsGround);

		catBody.velocity = new Vector2 (moveSpeed, catBody.velocity.y);

		//jump key
		if (Input.GetKeyDown (KeyCode.Space)) {
			if (grounded) {
				catBody.velocity = new Vector2 (catBody.velocity.x, jumpForce);	
			}
		}
		//animation triggers

		animator.SetBool ("Grounded", grounded);
	}
//	void onCollisionEnter2D (Collision2D other)
//	{
//		if(other.gameObject.tag == "killbox"
//			{
//				theGameManeger.RestartGame();
//			}
//	}
}
