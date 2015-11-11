using UnityEngine;
using System;
using System.Collections;
using System.IO;

public enum WeaponType {Pistol, TommyGun, Brass}

public class EnemyAI : MonoBehaviour {

	[HideInInspector] public bool facing_right = true;
	[HideInInspector] public bool jump = true;

	public float health = 100f;

	public float move_force = 365f;
	public float max_speed = 4f;
	public bool seen = false;
	public bool in_range = false;
	public float range = 1f;
	public WeaponType weapon;
	public GameObject bullet;
	public float bullet_force;
	public float fire_rate;
	private float last_shot = 0f;


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

		if (health <= 0)
			Destroy (this.gameObject);

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
				if (Time.time > fire_rate + last_shot) {
					Shoot();
					last_shot = Time.time;
				}
			}

		}

	}

	void Shoot() {
		Debug.Log("Shoot()");
		GameObject clone = Instantiate (bullet, transform.position, transform.rotation) as GameObject;
		clone.GetComponent<Rigidbody2D>().AddRelativeForce(transform.right * bullet_force);
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

		if (h > 0 && !facing_right) {
			Flip ();
			//transform.Rotate (Vector3.forward * -90);
		} else if (h < 0 && facing_right) {
			Flip ();
			//transform.Rotate (Vector3.forward * -90);
		}
	}

	void Flip() {
		facing_right = !facing_right;
		if (facing_right)
			transform.eulerAngles = new Vector3(0, 0, 0);
		if (!facing_right)
			transform.eulerAngles = new Vector3(0, 180, 0);
		//Vector2 the_scale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
		//transform.localScale = the_scale;
	}

	void OnTriggerEnter2D(Collider2D other) {
		Debug.Log("enter");
		GameObject collided_with = other.gameObject;
		if ( collided_with.tag == "Player" ) {
			seen = true;
			BoxCollider2D bc = GetComponent<BoxCollider2D> ();
			bc.enabled = false;
		}
		if (collided_with.tag == "PProj") {

		}
	}

}
