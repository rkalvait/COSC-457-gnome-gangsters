using UnityEngine;
using System.Collections;

public class CenaCollider : MonoBehaviour {

	public static GameObject CurentMusic;

	public GameObject imagined;
	public GameObject cena;
	public GameObject JOHNNY;
	private bool CenaStarted = false;

	void Start() {
		PlayerController.CurrentMusic = imagined;
	}

	public void OnTriggerEnter2D(Collider2D coll) {
		if (coll.tag == "Player" && !CenaStarted) {
			CenaStarted = true;
			PlayerController.CurrentMusic.GetComponent<AudioSource>().Pause ();
			cena.GetComponent<AudioSource>().Play();
			JOHNNY.GetComponent<bosstime>().WakeUp();

			PlayerController.CurrentMusic = cena;
		}
	}
}
