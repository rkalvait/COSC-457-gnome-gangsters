using UnityEngine;
using System.Collections;

public class Dorito : MonoBehaviour {

	//modified bullet script

	int duration;
	float random;

	void Start() {
		random = Random.value*2;
		duration = 100;
	}

	// Update is called once per frame
	void FixedUpdate () {
		if(random >= 1)
			this.transform.Rotate(0.0f, 0.0f, 10.0f);
		else
			this.transform.Rotate(0.0f, 0.0f, -10.0f);

		duration -= 1;
		if (duration <= 0)
		{
			Destroy(this.gameObject);
		}

	}

	void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.tag == "Player" || collision.tag == "Untagged") {
			Destroy(this.gameObject);
		}

		if (collision.tag == "Block_Maker") {
			Destroy (collision.gameObject);
			Destroy(this.gameObject);
		}

		//if (collision.tag == "Mob")
		//Destroy (collision.gameObject);
	}
}
