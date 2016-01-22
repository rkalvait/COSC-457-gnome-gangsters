using UnityEngine;
using System.Collections;

public class ArmController : MonoBehaviour {

    public GameObject player;
	public Camera cam;
	public AudioClip airhorn;
    float angleX, angleY, angle;
    public float distFromCamera = 10.0f;
    public GameObject projectile;
    public GameObject projectile2;
    float fireballSpeed = 50.0f;
    Vector3 mousePos;
    Vector3 anglePos;
	AudioSource audio;
	public bool chargeShot = true;
	bool charging = false;
	GameObject chargeClone;
	// Use this for initialization
	void Start () {
		this.audio = GetComponent<AudioSource> ();
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
        if (Input.GetButtonDown ("Fire1") && !chargeShot) {
			this.audio.PlayOneShot (airhorn);
			GameObject clone;
			Vector3 transformForward = transform.position+Vector3.Normalize(anglePos);
			clone = (GameObject)Instantiate (projectile, transformForward, transform.rotation);
			clone.transform.LookAt (mousePos);
			//clone.GetComponent<Rigidbody2D>().AddForce(new Vector2(stupid.x, stupid.y) * fireballSpeed, 0);

			clone.GetComponent<Rigidbody2D> ().velocity = Vector3.Normalize (clone.transform.forward) * fireballSpeed;

			clone.GetComponent<Rigidbody2D> ().velocity = clone.transform.forward * fireballSpeed;

		} 

		//For charge shot, start charging
		else if (Input.GetButtonDown ("Fire1") && chargeShot) {
			charging = true;
			Vector3 transformForward = transform.position+Vector3.Normalize(anglePos);
			chargeClone = (GameObject)Instantiate(projectile, transformForward, transform.rotation);
			chargeClone.transform.LookAt (mousePos);
			chargeClone.transform.localScale -= new Vector3(0.3f, 0.3f, 0.3f);

		}
		//continue charging
		if (Input.GetButton ("Fire1") && charging) {
			Vector3 transformForward = transform.position+Vector3.Normalize(anglePos);
			chargeClone.transform.position = transformForward;
			chargeClone.transform.LookAt (mousePos);
			if(chargeClone.transform.localScale.x <= 2f)
			{
				chargeClone.transform.localScale += new Vector3(0.03f, 0.03f, 0.03f);
			}
		}
		//fire charge shot
		if (Input.GetButtonUp ("Fire1") && charging) {
			charging = false;
			chargeClone.GetComponent<Rigidbody2D> ().velocity = Vector3.Normalize (chargeClone.transform.forward) * fireballSpeed;
			
			chargeClone.GetComponent<Rigidbody2D> ().velocity = chargeClone.transform.forward * fireballSpeed;
		}


        if (Input.GetButtonDown("Fire2"))
        {
            GameObject clone;
            clone = (GameObject)Instantiate(projectile2, transform.position, transform.rotation);
            clone.transform.LookAt(mousePos);
			clone.GetComponent<Rigidbody2D>().velocity = Vector3.Normalize(clone.transform.forward) * fireballSpeed;
        }

    }

}
