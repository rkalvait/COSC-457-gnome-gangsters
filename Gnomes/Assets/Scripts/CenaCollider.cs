using UnityEngine;
using System.Collections;

public class CenaCollider : MonoBehaviour {


	public GameObject imagined;
	public GameObject cena;
	public GameObject JOHNNY;
	private bool CenaStarted = false;
	
	public void OnTriggerEnter2D(Collider2D coll) {
		if (coll.tag == "Player" && !CenaStarted) {
			CenaStarted = true;
			imagined.GetComponent<AudioSource>().Pause ();
			cena.GetComponent<AudioSource>().Play();
			JOHNNY.GetComponent<bosstime>().WakeUp();
		}
	}
}
