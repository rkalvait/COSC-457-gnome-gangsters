using UnityEngine;
using System.Collections;

public class testplums : MonoBehaviour {
	
	public AudioClip plum;
	public AudioClip nice;
	public int count;
	public float time;

	AudioSource a;

	// Use this for initialization
	void Start () {
		a = GetComponent<AudioSource> ();
		for (int i=0; i<count; i++) {

			float x = Random.Range(0f, time);

			Invoke ("Plums", x);
		}
		Invoke ("Nice", time+plum.length);
	}

	void Nice() {
		a.PlayOneShot (nice);
	}

	void Plums() {
		a.PlayOneShot (plum);
	}

}
