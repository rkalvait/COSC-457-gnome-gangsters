using UnityEngine;
using System.Collections;

public class ImpossiFOV : MonoBehaviour {
	public GameObject impossibru;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void LateUpdate () {
		this.transform.position = impossibru.transform.position;
	}

	void OnTriggerEnter2D(Collider2D other) {
		//Debug.Log("enter");
		GameObject collided_with = other.gameObject;
		if ( collided_with.tag == "Player" ) {
			impossibru.GetComponent<ImpossibruAI>().seen = true;
			CircleCollider2D cc = GetComponent<CircleCollider2D> ();
			cc.enabled = false;
			//Debug.Log("Working");
		}
	}
}
