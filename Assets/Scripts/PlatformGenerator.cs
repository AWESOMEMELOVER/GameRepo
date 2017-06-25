using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGenerator : MonoBehaviour {

	public GameObject generatedPlatform;
	public Transform generationPoint;
	public float distanceWidthMin , distanceWidthMax;
	private float  platformWidth,distanceBetween;

	public ObjectPooler objectPool;


	void Start(){
		platformWidth = generatedPlatform.GetComponent<BoxCollider2D> ().size.x;
	}

	void Update(){

		if (transform.position.x < generationPoint.position.x) {
			distanceBetween = Random.Range (distanceWidthMin, distanceWidthMax);


			transform.position = new Vector3 (transform.position.x + platformWidth + distanceBetween, transform.position.y, transform.position.z);

			//get new platform from already created platformPool
			GameObject newPlatform = objectPool.GetPooledObject();
			newPlatform.transform.position = transform.position;
			newPlatform.transform.rotation = transform.rotation;
			newPlatform.SetActive (true);
		}

	}

}
