﻿using UnityEngine;
using System.Collections;

public class Switch : MonoBehaviour {

	public GameObject panel;

	public void OnTriggerEnter2D(Collider2D col) {
		if (col.tag == "Fireball") {
			panel.GetComponent<MovePanel>().isMoving = true;	
		}
	}
}
