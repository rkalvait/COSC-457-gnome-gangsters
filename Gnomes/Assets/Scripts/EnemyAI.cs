using UnityEngine;
using System;
using System.Collections;
using System.IO;

public enum WeaponType {Pistol, TommyGun, Brass}

public class EnemyAI : MonoBehaviour {

	[HideInInspector] public bool facing_right = true;
	[HideInInspector] public bool jump = true;

	public float health = 100;

	public float move_force = 365f;
	public float max_speed = 4f;
	public bool seen = false;
	public bool in_range = false;
	public float range = 1f;
	public WeaponType weapon;


	//public Transform ground_check;

	//private bool grounded = false;
	private Animator anim;
	private Rigidbody2D rb2d;
	//private float movex = 0f;
	//private float movey = 0f;
	
	// Use this for initialization
	void Awake () {
		anim = GetComponent<Animator>();
		rb2d = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {

		if (seen) {

			Vector3 player_pos = PlayerController.player.transform.position;
			float distance = Vector3.Distance(transform.position, player_pos);
			if (distance < range)
				in_range = true;
			else
				in_range = false;

			if (player_pos.x < transform.position.x && facing_right == true)
				Flip();
			if (player_pos.x > transform.position.x && facing_right == false)
				Flip();

			if (!in_range) {
				Movement ();
			} else if (in_range) {
				Shoot();
			}

		}

	}

	void Shoot() {
		Debug.Log("Shoot()");
	}

	void Movement() {
		Debug.Log("Movement()");
		float h = 1;
		anim.SetFloat ("Speed", Mathf.Abs (h));

		if (facing_right == true) {
			h = 1;
		} else {
			h = -1;
		}
		if (h*rb2d.velocity.x < max_speed)
			rb2d.AddForce (Vector2.right * h * move_force);
		if (Mathf.Abs (rb2d.velocity.x) > max_speed)
			rb2d.velocity = new Vector2 (Mathf.Sign (rb2d.velocity.x) * max_speed, rb2d.velocity.x);
		//transform.Translate (Vector2.right * speed * Time.deltaTime);

		if (h > 0 && !facing_right)
			Flip ();
		else if (h < 0 && facing_right)
			Flip ();
	}

	void Flip() {
		facing_right = !facing_right;
		Vector2 the_scale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
		transform.localScale = the_scale;
	}

	void OnTriggerEnter2D(Collider2D other) {
		//Debug.Log("enter");
		//BoxCollider2D bc = GetComponent<BoxCollider2D> ();
		seen = true;
	}

	void OnTriggerStay2D(Collider2D other) {
		Debug.Log("stay");
	}

}
