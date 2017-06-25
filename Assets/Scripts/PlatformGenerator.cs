using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGenerator : MonoBehaviour {

	public GameObject generatedPlatform;
	public Transform generationPoint;
	public float distanceWidthMin , distanceWidthMax,distanceBetween;
	private float  platformWidth;
	private int randomizeSelector;
	//public GameObject[] platformsArray;
	private float[] platformsWidths;

	public ObjectPooler[] objectPools;


	void Start(){
		//platformWidth = generatedPlatform.GetComponent<BoxCollider2D> ().size.x;
		platformsWidths = new float[objectPools.Length];

		for(int i = 0 ; i<objectPools.Length; i++){
			platformsWidths [i] = objectPools[i].pooledObject.GetComponent<BoxCollider2D> ().size.x;
		}
	}

	void Update(){

		if (transform.position.x < generationPoint.position.x) {
			distanceBetween = Random.Range (distanceWidthMin, distanceWidthMax);

			randomizeSelector = Random.Range (0, objectPools.Length);

			transform.position = new Vector3 (transform.position.x + (platformsWidths[randomizeSelector] / 2) + distanceBetween, transform.position.y, transform.position.z);





			//Instantiate (objectPools[randomizeSelector], transform.position, transform.rotation);



			//get new platform from already created platformPool
			GameObject newPlatform = objectPools[randomizeSelector].GetPooledObject();
			newPlatform.transform.position = transform.position;
			newPlatform.transform.rotation = transform.rotation;
			newPlatform.SetActive (true);

			transform.position = new Vector3 (transform.position.x + (platformsWidths[randomizeSelector] / 2), transform.position.y, transform.position.z);

		}

	}

}
