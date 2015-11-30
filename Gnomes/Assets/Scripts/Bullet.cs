using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

	public int duration;
	public float speed;
	public GameObject bullet;
	Rigidbody2D rb2d;

	void Awake() {
		//Vector2(
		//rb2d.AddForce (force);
	}

	// Use this for initialization
	void Start() {
		if (transform.rotation.y == 180)
			transform.eulerAngles = new Vector3(0, 180, 0);
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		Debug.Log ("bullet update");
		duration -= 1;
		if (duration <= 0)
		{
			Destroy(this.gameObject);
		}
	}
	

}
