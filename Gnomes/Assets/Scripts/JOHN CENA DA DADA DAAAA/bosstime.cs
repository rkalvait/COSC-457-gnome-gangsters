﻿using UnityEngine;
using System.Collections;

public class bosstime : MonoBehaviour {
	
	public AudioClip hitmarker;
	public GameObject DogePrefab;
	public GameObject Impossibru;
	public GameObject DoritoPrefab;
	public GameObject HPBar;
	public GameObject HPBar_Parent;
	public GameObject TextBoxPefab;
	public GameObject PressFPrefab;
	public Sprite openmouth;
	public Sprite closemouth;
	public GameObject imagined;
	public GameObject cena;
	public GameObject player;
	public float FireDelay;
	public bool ___________________;
	GameObject TextBox;
	TextMesh mesh;
	bool fireType = false;
	bool active = false;
	int count = 0;
	public int HP;
	AudioSource audio;

	// Use this for initialization
	void Start () {
		audio = GetComponent<AudioSource> ();
		HP = 10;
	}

	void Update() {
		if (Time.deltaTime == 0 && Input.GetKeyDown (KeyCode.Space)) {
			DeathSequence();
		}
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
			Invoke ("OneDorito", 0.1f *i);
		}

		Invoke("DoritoBeam", 20);
	}

	public void OneDorito() {
		GameObject dorito = Instantiate(DoritoPrefab);
		dorito.transform.position = this.transform.position + new Vector3(-3.21f, 1.76f, 4f);
		dorito.GetComponent<Rigidbody2D>().isKinematic = true;
		dorito.transform.localScale = new Vector3(1.0f, 1.0f, 1f);
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
			this.audio.PlayOneShot(hitmarker);
			HP -= 1;
			if (HP <= 0) {
				DeathSequence();
			}
			HPBar.transform.localScale = new Vector3(HP*0.7466026f/100f, HPBar.transform.localScale.y, HPBar.transform.localScale.z);
		}
	}

	// Spawn the text box and change the text before he dies
	void DeathSequence() {
		switch (count) {
		case 0:
			Time.timeScale = 0;
			PlayerController.CurrentMusic.GetComponent<AudioSource>().Pause ();
			Destroy(HPBar_Parent);
			TextBox = Instantiate(TextBoxPefab) as GameObject;
			TextBox.transform.position = new Vector3(82.05f, -7.18f, -5.71f);
			mesh = TextBox.GetComponentInChildren<TextMesh>() as TextMesh;
			mesh.text = "> be me";
			break;
		case 1:
			mesh.text = mesh.text+"\n> in charge of keeping gnomes\n out of elf city";
			break;
		case 2:
			mesh.text = mesh.text+"\n> tfw defeated";
			break;
		case 3:
			mesh.text = "> feelsbadman.jpg";
			break;
		case 4:
			mesh.text = mesh.text+"\n> rip in kill me";
			break;
		default:
			GameObject f = Instantiate(PressFPrefab) as GameObject;
			f.GetComponent<PressF>().TextBox = TextBox;
			Time.timeScale = 1;
			Destroy(gameObject);
			break;
		}

		count++;
	}

	void OnDestroy() {

		if (!ShreckMusic.shrekstarted) {
			imagined.GetComponent<AudioSource> ().UnPause ();
			PlayerController.CurrentMusic = imagined;
		} else {
			ShreckMusic.getShrecked.GetComponent<AudioSource> ().UnPause ();
			PlayerController.CurrentMusic = ShreckMusic.getShrecked;
		}
		cena.GetComponent<AudioSource>().Stop ();
	}
}
