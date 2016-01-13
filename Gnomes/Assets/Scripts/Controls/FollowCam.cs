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
		destination.y = poi.transform.position.y; //-(poi.transform.position.y/3);
		destination.z = transform.position.z;
		transform.position = Vector3.Lerp (transform.position, destination, 0.1f);
	}
}
