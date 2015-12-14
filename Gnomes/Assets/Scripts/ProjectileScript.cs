using UnityEngine;
using System.Collections;

public class ProjectileScript : MonoBehaviour {
    public int timer;
	public GameObject projectile1;
	public GameObject projectile2;
	// Use this for initialization
	void Start () {
        timer = 100;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        timer -= 1;
        if (timer == 0)
        {
            Destroy(this.gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
		if (collision.tag != "Player" && collision.tag != "Fireball" && collision.tag != "NoCollide" && collision.tag != "Particle") {


			onDestroy();
			Destroy (this.gameObject);
		}

		//if (collision.tag == "Mob")
			//Destroy (collision.gameObject);
    }

	void onDestroy()
	{
		float randomX;
		float randomY;
		float randomVal;
		GameObject clone1;
		for (int i = 0; i < 4; i++) {
			randomVal = Random.value*2;
			randomX = transform.position.x + Random.value*2-1;
			randomY = transform.position.y + Random.value*2-1;
			if(randomVal > 1)
				clone1 = (GameObject) Instantiate(projectile1, transform.position, Quaternion.Euler(0,0,0));
			else
				clone1 = (GameObject) Instantiate(projectile2, transform.position, Quaternion.Euler(0,0,0));

			clone1.transform.LookAt(new Vector3(randomX, randomY, 0f));
			clone1.GetComponent<Rigidbody2D>().velocity = clone1.transform.forward * 15.0f;
			//clone1.transform.position = new Vector3(clone1.transform.position.x, clone1.transform.position.y, 0.0f);
		}

	}
}
