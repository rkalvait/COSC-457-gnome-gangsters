using UnityEngine;
using System.Collections;

public class MovePanel : MonoBehaviour {
		
	private bool up = false;
	public bool isMoving = false;

	// Update is called once per frame
	void FixedUpdate () {
		if (!isMoving)
			return;
		if (up) {
			gameObject.transform.position += new Vector3 (0f, 0.2f, 0f);
		} else {
			gameObject.transform.position += new Vector3 (0f, -0.2f, 0f);
		}
	}

	void OnTriggerEnter2D(Collider2D col) {
		if (col.tag == "bounds") {
			up = !up;
		}
	}
}
