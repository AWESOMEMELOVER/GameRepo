using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundRepeating : MonoBehaviour {
	private BoxCollider2D groundCollider;
	private float groundHorizontalLenth;

	public PlayerController thePlayer;
	private Vector3 lastPlayerPosition;
	private float distanceToMove;
	// Use this for initialization
	void Start () {
		groundCollider = GetComponent <BoxCollider2D> ();
		groundHorizontalLenth = groundCollider.size.x -10;
		thePlayer = FindObjectOfType<PlayerController> ();
		lastPlayerPosition = thePlayer.transform.position;

	}
	
	// Update is called once per frame
	void Update ()
	{
		if (transform.position.x < -groundHorizontalLenth) {
			RepositionBackground ();
		}

	}
	private void RepositionBackground()
	{
	Vector2 groundOffset = new Vector2 (groundHorizontalLenth * 1f, 0);
		//transform.position = (Vector2)transform.position + groundOffset*2;
		distanceToMove = thePlayer.transform.position.x - lastPlayerPosition.x;

		this.transform.position = new Vector3 (thePlayer.transform.position.x,transform.position.y,transform.position.z);

		//find transfrom component of player
		lastPlayerPosition = thePlayer.transform.position;
		}
}
