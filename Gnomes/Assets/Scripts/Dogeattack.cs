using UnityEngine;
using System.Collections;

public class Dogeattack : MonoBehaviour {

	public GameObject player;
	public int speed;
	
	// Update is called once per frame
	void Update () { 
		Vector3 direction3D = player.transform.position - transform.position;
		Vector2 direction = (Vector2) Vector3.Normalize(new Vector3(direction3D.x, direction3D.y, 0));

		
		var angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
		transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

		//Debug.Log(transform.rotation.z);

		if (Mathf.Abs(transform.rotation.z) > Mathf.PI / 4) {
			transform.localScale = new Vector3(1, -1, 1);
		} else {
			transform.localScale = new Vector3(1, 1, 1);
		}

		GetComponent<Rigidbody2D>().AddRelativeForce(speed * direction);
	}
}
