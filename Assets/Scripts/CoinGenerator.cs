using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinGenerator : MonoBehaviour {

	public ObjectPooler coinPool;

	public float distanceBetweenCoins;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void SpawnCoins(Vector3 startPosition){
	
		GameObject coin1 = coinPool.GetPooledObject ();
		coin1.transform.position = startPosition;
		coin1.SetActive (true);

		GameObject coin2 = coinPool.GetPooledObject ();
		coin1.transform.position = new Vector3 (startPosition.x - distanceBetweenCoins, startPosition.y, startPosition.z);
		coin1.SetActive (true);


	}
}
