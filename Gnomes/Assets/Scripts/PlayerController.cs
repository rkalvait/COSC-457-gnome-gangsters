using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
	static public PlayerController player;

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
        if (Input.GetKey(KeyCode.A))
        {
            movex = -1f;
            //D to move right
        }
        else if (Input.GetKey(KeyCode.D))
        {
            movex = 1f;
        }
        else
        {
            if (movex > 0)
            {
                movex -= 0.015f;
            }
            if (movex < 0)
            {
                movex += 0.015f;
            }
            if (!isJumping)
            {
                movex = 0f;
            }
        }
        //jump if not already in air
        if (Input.GetKeyDown(KeyCode.Space) && isJumping == false)
        {
            rb.AddForce(new Vector2(0, 400));
        }
        //make sure player does not get stuck to ground
        if (rb.velocity.y <= 0.01 && rb.velocity.y >= -0.01)
        {
            isJumping = false;
        }

    }

    void FixedUpdate()
    {
        rb.velocity = new Vector2(movex * Speed, rb.velocity.y);
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
				rb.AddForce (Vector2.right * 3500);
			} else {
				Debug.Log ("else");
				rb.AddForce (Vector2.left * 3500);
			}
		} else {
		}
			//Debug.Log ("herpaderp");
		//Destroy(this.gameObject);
	}
}
