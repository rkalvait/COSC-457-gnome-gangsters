using UnityEngine;
using System.Collections;

public class PressF : MonoBehaviour {

	public GameObject TextBox;
	private bool PlayerNear = false;
	
	// Update is called once per frame
	void Update () {
		if (PlayerNear && Input.GetKeyDown (KeyCode.F)) {
			TextMesh mesh = TextBox.GetComponentInChildren<TextMesh>() as TextMesh;
			mesh.text = "> you pay you're respects.";
		}
	}

	void OnTriggerEnter2D(Collider2D coll) {
		if (coll.tag == "Player") {
			PlayerNear = true;
		}
	}

	void OnTriggerExit2D(Collider2D coll) {
		if (coll.tag == "Player") {
			PlayerNear = false;
		}
	}
}
