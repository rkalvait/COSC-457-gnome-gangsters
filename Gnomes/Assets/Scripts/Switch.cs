using UnityEngine;
using System.Collections;

public class Switch : MonoBehaviour {

	public GameObject panel;

	public void OnTriggerEnter2D(Collider2D col) {
		if (col.tag == "projectile") {
			panel.GetComponent<Rigidbody2D>().WakeUp();
		}
	}
}
