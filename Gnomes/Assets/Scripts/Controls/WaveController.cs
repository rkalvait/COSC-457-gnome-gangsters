using UnityEngine;
using System.Collections;

//Works for the things attached to the player as well
public class WaveController : MonoBehaviour
{

	static public WaveController cam;
	public bool ______________________;
	public GameObject poi;

	void Awake() {
		cam = this;
	}

	// Update is called once per frame
	void Update () {
		Vector3 destination;
		destination.x = poi.transform.position.x - 2.0f;
		destination.y = poi.transform.position.y; //-(poi.transform.position.y/3);
		destination.z = transform.position.z;
		transform.position = Vector3.Lerp (transform.position, destination, 0.1f);
	}
}

