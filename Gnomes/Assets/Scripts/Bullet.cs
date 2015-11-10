using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

	public int timer;
	// Use this for initialization
	
	// Update is called once per frame
	void FixedUpdate () {
		timer -= 1;
		if (timer == 0)
		{
			Destroy(this.gameObject);
		}
	}
	
	void OnCollisionEnter(Collision collision)
	{
		Destroy(this.gameObject);
	}
}
