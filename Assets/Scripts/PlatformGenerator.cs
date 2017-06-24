using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGenerator : MonoBehaviour {

	public GameObject generatingPlatform;
	public Transform generationPoint;
	public float distanceBetween;
	private float platformWidth;

	// Use this for initialization
	void Start () {
		platformWidth = generationPoint.GetComponent<BoxCollider2D> ().size.x;
	}
	
	// Update is called once per frame
	void Update () {

		if (transform.position.x < generationPoint.position.x) {
			transform.position = new Vector3 (transform.position.x + platformWidth + distanceBetween, transform.position.y, transform.position.z);
			//create copy of already existing object
			Instantiate (generatingPlatform , transform.position, transform.rotation);
		}
	}
}
