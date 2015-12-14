using UnityEngine;
using System.Collections;

public class ShreckMusic : MonoBehaviour {

	public GameObject getShrecked;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void OnTriggerEnter2D(Collider2D coll) {
		if (coll.tag == "Player") {
			getShrecked.GetComponent<AudioSource>().Play();
		}
	}

	public void OnTriggerExit2D(Collider2D coll) {
		if (coll.tag == "Player") {
			getShrecked.GetComponent<AudioSource>().Pause();
		}
	}
}
