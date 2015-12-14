using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
	static public PlayerController player;
	static public GameObject CurrentMusic;

    public float Speed = 10f;
	public bool ____________________________;
	public Rigidbody2D rb;
	public bool isJumping = false;
	private float movex = 0f;
	//private int jump_count = 1;
    //private float movey = 0f;

    // Use this for initialization
    void Start()
    {
		player = this;
        //change gravity value
        //Physics.gravity = new Vector3(0, -15.0f, 0);
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //A to move left
        if (Input.GetKey (KeyCode.A)) {
			rb.velocity = new Vector2 (-Speed, rb.velocity.y);
			//rb.AddForce(new Vector2(-Speed, 0));
			//D to move right
		} else if (Input.GetKey (KeyCode.D)) {
			rb.velocity = new Vector2 (Speed, rb.velocity.y);
			//rb.AddForce(new Vector2(Speed, 0));
		} else  if (isJumping) {
			//rb.velocity = new Vector2 (0, rb.velocity.y);
		}

        //jump if not already in air
        if (Input.GetKeyDown(KeyCode.Space) && isJumping == false)
        {
            rb.velocity = new Vector2(rb.velocity.x, 10);
        }
        //make sure player does not get stuck to ground
        if (rb.velocity.y <= 0.01 && rb.velocity.y >= -0.01) {
			isJumping = false;
		} else {
			isJumping = true;
		}
		if (Input.GetKey (KeyCode.S)) {
			rb.AddForce(new Vector2(0, -25));
		}

    }

	void FixedUpdate() {
		if (rb.velocity.x > 0) {
			rb.velocity = new Vector2 (rb.velocity.x-1, rb.velocity.y);
		} else if (rb.velocity.x < 0) {
			rb.velocity = new Vector2 (rb.velocity.x+1, rb.velocity.y);
		}
	}

	void OnTriggerEnter2D(Collider2D collision)
	{
		//Debug.Log ("should this be 2D");
		//GameObject collided_with = collision.gameObject;
		if (collision.tag == "Bullet") {
			Debug.Log ("is bullet");
			float diff = collision.transform.position.x - transform.position.x;
			if (diff < 0) {
				Debug.Log ("if");
				rb.AddForce (Vector2.right * 1000);
			} else {
				Debug.Log ("else");
				rb.AddForce (Vector2.left * 1000);
			}
		} else {
		}
			//Debug.Log ("herpaderp");
		//Destroy(this.gameObject);
	}
}
