using UnityEngine;
using System.Collections;

public class FollowCam : MonoBehaviour {

	static public FollowCam cam;
	public bool ______________________;
	public GameObject poi;
	
	void Awake() {
		cam = this;
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 destination;
		destination.x = poi.transform.position.x;
		destination.y = poi.transform.position.y;
		destination.z = transform.position.z;
		transform.position = destination;
	}
}
