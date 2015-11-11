using UnityEngine;
using System.Collections;

public class ArmController : MonoBehaviour {

	public Camera camera;
    public GameObject player;
    float angleX, angleY, angle;
    public float distFromCamera = 10.0f;
    public GameObject projectile;
    float fireballSpeed = 25.0f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        
        //transform.position = player.transform.position + new Vector3(0.3f, 0, 0);

        Vector3 mousePos = Input.mousePosition;

        //To make mousePos relative to center of screen
        //mousePos.x -= Screen.width / 2;
        //mousePos.y -= Screen.height / 2;

        //To make mousePos relative to transform
		mousePos -= camera.WorldToScreenPoint (transform.position);
        angle = Vector3.Angle(mousePos, Vector3.up);

        //For 360 degree angle
        if (mousePos.x > 0)
            angle = 360 - angle;

        //make weapon same length on each side
        if (angle <= 180)
		{
			player.transform.localScale = new Vector3(-1f, 1f, 1f);
			transform.rotation = Quaternion.Euler(0, 0, 90-angle);
        }
        else
		{
			player.transform.localScale = new Vector3(1f, 1f, 1f);
			transform.rotation = Quaternion.Euler(0, 0, angle+90);
        }

        

        //Fire projectile
        if (Input.GetButtonDown("Fire1"))
        {
            GameObject clone;
            clone = (GameObject) Instantiate(projectile, transform.position, transform.rotation);
            clone.transform.LookAt(mousePos);
            //clone.GetComponent<Rigidbody2D>().AddForce(new Vector2(stupid.x, stupid.y) * fireballSpeed, 0);
            clone.GetComponent<Rigidbody2D>().velocity = clone.transform.forward * fireballSpeed;
        }


    }

}
