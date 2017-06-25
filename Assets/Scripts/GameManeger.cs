using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManeger : MonoBehaviour {
	public Transform platformGenerator;
	private Vector3 platformStartPoint;

	public PlayerController thePlayer;
	private Vector3 playerStartPoint;

	// Use this for initialization
	void Start () {
		platformStartPoint = platformGenerator.position;
		playerStartPoint = thePlayer.transform.position;
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	/*public void RestartGame()
	{
		StartCoroutine ("RestartGameCo");
	}
	public IEnumerator RestartGameCo(){
		thePlayer.gameObject.SetActive (false);
		yield return new WaitForSeconds (0.5f);
		thePlayer.transform.position = playerStartPoint;
		platformGenerator.position = platformStartPoint;
		thePlayer.gameObject.SetActive (true);
	}*/
}

