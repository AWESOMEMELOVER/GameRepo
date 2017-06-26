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

	private float minHeight;
	public Transform maxHeightPoint;
	private float maxHeight;
	public float maxHeightChange;
	private float heightChange;
	private CoinGenerator coinGenerator;
	public float randomCoinMaxCuantity;
	public float randomMonsterTreashhold;
	public ObjectPooler monsterPool;
	public ObjectPooler backGroundPool;


	void Start(){
		//platformWidth = generatedPlatform.GetComponent<BoxCollider2D> ().size.x;
		platformsWidths = new float[objectPools.Length];

		for(int i = 0 ; i<objectPools.Length; i++){
			platformsWidths [i] = objectPools[i].pooledObject.GetComponent<BoxCollider2D> ().size.x;
		}
		minHeight = transform.position.y;
		maxHeight = maxHeightPoint.position.y;

		coinGenerator = FindObjectOfType<CoinGenerator> ();

	}

	void Update(){

		if (transform.position.x < generationPoint.position.x) {
			distanceBetween = Random.Range (distanceWidthMin, distanceWidthMax);

			randomizeSelector = Random.Range (0, objectPools.Length);

			heightChange = transform.position.y + Random.Range (maxHeightChange, -maxHeightChange);

			if (heightChange > maxHeight) {
				heightChange = maxHeight;
			}else if(heightChange < minHeight){
				heightChange = minHeight;
			}

			transform.position = new Vector3 (transform.position.x + (platformsWidths[randomizeSelector] / 2) + distanceBetween, heightChange, transform.position.z);







			//get new platform from already created platformPool
			GameObject newPlatform = objectPools[randomizeSelector].GetPooledObject();
			newPlatform.transform.position = transform.position;
			newPlatform.transform.rotation = transform.rotation;
			newPlatform.SetActive (true);

			if (Random.Range (0f, 100f) < randomCoinMaxCuantity) {
				coinGenerator.SpawnCoins (new Vector3 (transform.position.x, transform.position.y + 1f, transform.position.z));
			}
			if (Random.Range (0f, 100f) < randomMonsterTreashhold) {
				GameObject newMonster = monsterPool.GetPooledObject ();

				Vector3 monsterPosition = new Vector3 (0f, 1.5f, 0f);

				newMonster.transform.position = transform.position+monsterPosition;
				newMonster.transform.rotation = transform.rotation;
				newMonster.SetActive (true);
			}


			transform.position = new Vector3 (transform.position.x + (platformsWidths[randomizeSelector] / 2), transform.position.y, transform.position.z);

		}

	}

}
