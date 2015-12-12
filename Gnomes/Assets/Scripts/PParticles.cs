using UnityEngine;
using System.Collections;

public class PParticles : MonoBehaviour {


	int duration;
	float random;
	int minDur;
	void Start() {
		random = Random.value*2;
		duration = 200;
		minDur = 50;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if(random >= 1)
			this.transform.Rotate(0.0f, 0.0f, 10.0f);
		else
			this.transform.Rotate(0.0f, 0.0f, -10.0f);
		
		duration -= 1;
		minDur -= 1;
		if (duration <= 0)
		{
			Destroy(this.gameObject);
		}
		
	}
	
	void OnTriggerEnter2D(Collider2D collision)
	{

		if (collision.tag != "Player" && collision.tag != "Fireball" && collision.tag != "NoCollide" && collision.tag != "Particle") {
			if(minDur <= 0)
				Destroy(this.gameObject);
		}
		
		//if (collision.tag == "Mob")
		//Destroy (collision.gameObject);
	}
	/*
	void OnTriggerStay2D(Collider2D collision)
	{
		if (collision.tag == "bounds") {
			Destroy(this.gameObject);
		}
	}
	*/
}
