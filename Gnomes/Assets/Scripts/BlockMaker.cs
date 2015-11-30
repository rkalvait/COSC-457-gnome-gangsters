﻿using UnityEngine;
using System.Collections;

public class BlockMaker : MonoBehaviour {
	public GameObject block;
	public int timer;
	// Use this for initialization
	void Start () {
		timer = 100;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		timer -= 1;
		if (timer == 0)
		{
			Destroy(this.gameObject);
		}
	}
	
	void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.tag != "player") 
		{
			DestroyAllObjects();
			GameObject clone;
			clone = (GameObject) Instantiate(block, transform.position, Quaternion.Euler(0, 0, 0));
			Destroy(this.gameObject);
		}


		Destroy (this.gameObject);
	}

	void DestroyAllObjects()
	{
		GameObject[] gameObjects;
		gameObjects = GameObject.FindGameObjectsWithTag ("Block_Maker");
		
		for(var i = 0 ; i < gameObjects.Length ; i ++)
		{
			Destroy(gameObjects[i]);
		}
	}
}
