using UnityEngine;
using System.Collections;

public class ArmController : MonoBehaviour {

    public GameObject player;
	public Camera cam;
    float angleX, angleY, angle;
    public float distFromCamera = 10.0f;
    public GameObject projectile;
    public GameObject projectile2;
    float fireballSpeed = 25.0f;
    Vector3 mousePos;
    Vector3 anglePos;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        

        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
		mousePos = new Vector3 (mousePos.x, mousePos.y, 0);
        anglePos = Input.mousePosition;
        anglePos -= cam.WorldToScreenPoint(transform.position);
        angle = Vector3.Angle(anglePos, Vector3.up);

        //For 360 degree angle
        if (anglePos.x > 0)
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
            transform.rotation = Quaternion.Euler(0, 0, 90+angle);
        }

        

        //Fire projectile
        if (Input.GetButtonDown("Fire1"))
        {

            GameObject clone;
            clone = (GameObject) Instantiate(projectile, transform.position, transform.rotation);
            clone.transform.LookAt(mousePos);
			clone.GetComponent<Rigidbody2D>().velocity = clone.transform.forward * fireballSpeed;

        }

        if (Input.GetButtonDown("Fire2"))
        {
            GameObject clone;
            clone = (GameObject)Instantiate(projectile2, transform.position, transform.rotation);
            clone.transform.LookAt(mousePos);
            clone.GetComponent<Rigidbody2D>().velocity = clone.transform.forward * fireballSpeed;
        }
    }

}
