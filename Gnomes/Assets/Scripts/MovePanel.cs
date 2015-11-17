using UnityEngine;
using System.Collections;

public class MovePanel : MonoBehaviour {
		
	public float speed = 0.1f;
	private bool up = false;
	public bool isMoving = false;

	// Update is called once per frame
	void FixedUpdate () {
		if (!isMoving)
			return;
		if (up) {
			//gameObject.transform.position += new Vector3 (0f, speed, 0f);
			gameObject.GetComponent<Rigidbody2D>().velocity = new Vector3(0f, speed, 0f);
		} else {
			//gameObject.transform.position += new Vector3 (0f, -speed, 0f);
			gameObject.GetComponent<Rigidbody2D>().velocity = new Vector3(0f, -speed, 0f);
		}
	}

	void OnTriggerEnter2D(Collider2D col) {
		if (col.tag == "bounds") {
			up = !up;
		}
	}
}
