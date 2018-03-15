using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCharacter : MonoBehaviour {

	public GameObject player;
	public GameObject[] playerSpawnLocation;

	// Use this for initialization
	void Start () 
	{
		//player.transform.position = playerSpawnLocation[Random.Range(0, playerSpawnLocation.Length)].transform.position;
	}

	void OnTriggerEnter(Collider other)
	{
		if(other.gameObject.tag == "Player")
		{
			SpawnPlayer();
		}
	}

	public void SpawnPlayer ()
	{
		player.transform.position = playerSpawnLocation[Random.Range(0, playerSpawnLocation.Length)].transform.position;
		player.transform.rotation = playerSpawnLocation [Random.Range (0, playerSpawnLocation.Length)].transform.rotation;
	}
}

