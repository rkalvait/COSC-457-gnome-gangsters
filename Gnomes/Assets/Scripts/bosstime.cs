using UnityEngine;
using System.Collections;

public class bosstime : MonoBehaviour {

	public GameObject DogePrefab;
	public GameObject HPBar;
	public GameObject HPBar_Parent;
	public Sprite openmouth;
	public Sprite closemouth;
	public GameObject imagined;
	public GameObject cena;
	public GameObject player;
	public bool ___________________;
	bool mouthopen = false;
	bool active = false;
	public int HP;

	// Use this for initialization
	void Start () {
		HP = 100;
	}

	public void WakeUp() {
		active = true;
		ShootDoge ();
	}

	public void ShootDoge() {
		if (mouthopen) {
			this.gameObject.GetComponent<SpriteRenderer>().sprite = closemouth;
		} else {
			this.gameObject.GetComponent<SpriteRenderer>().sprite = openmouth;
			GameObject Doge = Instantiate (DogePrefab);
			Doge.transform.position = this.transform.position + new Vector3(-2.59f, 0.3f, 14f);
			Doge.GetComponent<Dogeattack>().player = player;
		}
		mouthopen = !mouthopen;
		Invoke ("ShootDoge", 5);
	}

	void OnTriggerEnter2D(Collider2D collision) {
		if (!active) return;
		if (collision.tag == "Fireball") {
			HP -= 1;
			if (HP <= 0) {
				Destroy(this.gameObject);
				Destroy(HPBar_Parent);
			}
			HPBar.transform.localScale = new Vector3(HP*0.7466026f/100f, HPBar.transform.localScale.y, HPBar.transform.localScale.z);
		}
	}

	void OnDestroy() {
		imagined.GetComponent<AudioSource>().Stop ();
		cena.GetComponent<AudioSource>().UnPause();
	}
}
