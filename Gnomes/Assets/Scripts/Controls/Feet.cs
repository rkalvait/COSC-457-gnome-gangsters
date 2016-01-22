using UnityEngine;
using System.Collections;

public class Feet : MonoBehaviour {

	public GameObject player;

	public void OnCollisionStay2D(Collision2D coll) {
		player.GetComponent<PlayerController> ().isJumping = false;
	}

	public void OnCollisionExit2D(Collision2D coll) {
		player.GetComponent<PlayerController> ().isJumping = true;
	}
}
