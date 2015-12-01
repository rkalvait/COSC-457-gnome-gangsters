using UnityEngine;
using System.Collections;

public class CenaCollider : MonoBehaviour {


	public GameObject imagined;
	public GameObject cena;
	
	public void OnTriggerEnter2D(Collider2D coll) {
		if (coll.tag == "Player") {
			imagined.GetComponent<AudioSource>().Stop ();
			cena.GetComponent<AudioSource>().Play();
		}
	}
}
