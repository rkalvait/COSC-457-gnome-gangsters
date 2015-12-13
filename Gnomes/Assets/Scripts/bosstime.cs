using UnityEngine;
using System.Collections;

public class bosstime : MonoBehaviour {

	public GameObject DogePrefab;
	public GameObject Impossibru;
	public GameObject DoritoPrefab;
	public GameObject HPBar;
	public GameObject HPBar_Parent;
	public Sprite openmouth;
	public Sprite closemouth;
	public GameObject imagined;
	public GameObject cena;
	public GameObject player;
	public float FireDelay;
	public bool ___________________;
	bool fireType = false;
	bool active = false;
	public int HP;

	// Use this for initialization
	void Start () {
		HP = 100;
	}

	public void WakeUp() {
		active = true;
		ShootDoge ();
		DoritoBeam();
	}

	public void ShootDoge() {
		this.gameObject.GetComponent<SpriteRenderer>().sprite = openmouth;
		if (fireType) {
			GameObject Doge = Instantiate (DogePrefab);
			Doge.transform.position = this.transform.position + new Vector3(-2.59f, 0.3f, 14f);
			Doge.GetComponent<Dogeattack>().player = player;
		} else {
			GameObject imp = Instantiate(Impossibru);
			imp.transform.position = this.transform.position + new Vector3(-2.59f, 0.3f, 14f);
		}
		fireType = !fireType;
		Invoke ("ShootDoge", FireDelay);
		Invoke("CloseMouth", FireDelay/2);
	}

	public void DoritoBeam() {
		for (int i=0; i<10; i++) {
			Invoke ("OneDorito", 1f *i);
		}

		Invoke("DoritoBeam", 20);
	}

	public void OneDorito() {
		GameObject dorito = Instantiate(DoritoPrefab);
		dorito.transform.position = this.transform.position + new Vector3(-3.21f, 1.76f, 4f);
		dorito.GetComponent<Rigidbody2D>().isKinematic = true;
		dorito.transform.localScale = new Vector3(1.5f, 1.5f, 1f);
		Vector3 dpos = dorito.transform.position;
		Vector3 dorito2d = new Vector3(dpos.x, dpos.y, 0);
		Vector3 ppos = player.transform.position;
		Vector3 player2d = new Vector3(ppos.x, ppos.y, 0);
		dorito.GetComponent<Rigidbody2D>().velocity = (Vector2) Vector3.Normalize(ppos - dpos) * 10;
	}

	public void CloseMouth() {
		this.gameObject.GetComponent<SpriteRenderer>().sprite = closemouth;
	}

	void OnTriggerEnter2D(Collider2D collision) {
		if (!active) return;
		if (collision.tag == "Fireball") {
			HP -= 1;
			if (HP <= 0) {

				Destroy(gameObject);
				Destroy(HPBar_Parent);
			}
			HPBar.transform.localScale = new Vector3(HP*0.7466026f/100f, HPBar.transform.localScale.y, HPBar.transform.localScale.z);
		}
	}

	void OnDestroy() {
		Debug.Log("DED");
		imagined.GetComponent<AudioSource>().UnPause();
		cena.GetComponent<AudioSource>().Stop ();
	}
}
