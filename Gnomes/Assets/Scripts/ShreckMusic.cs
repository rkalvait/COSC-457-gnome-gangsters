using UnityEngine;
using System.Collections;

public class ShreckMusic : MonoBehaviour {

	static public GameObject getShrecked;
	public GameObject shrekm;
	public static bool shrekstarted = false;

	// Use this for initialization
	void Start () {
		getShrecked = shrekm;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void OnTriggerEnter2D(Collider2D coll) {
		if (coll.tag == "Player" && !shrekstarted) {
			shrekstarted = true;
			PlayerController.CurrentMusic.GetComponent<AudioSource>().Pause();
			getShrecked.GetComponent<AudioSource>().Play();
			PlayerController.CurrentMusic = getShrecked;
		}
	}

	//public void OnTriggerExit2D(Collider2D coll) {
	//	if (coll.tag == "Player") {
	//		getShrecked.GetComponent<AudioSource>().Pause();
	//	}
	//}
}
