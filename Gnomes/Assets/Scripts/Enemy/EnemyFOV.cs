using UnityEngine;
using System.Collections;

public class EnemyFOV : MonoBehaviour {

    public GameObject gnome;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void LateUpdate()
    {
        
        this.transform.position = gnome.transform.position;
        if (!gnome.GetComponent<EnemyAI>().facing_right)
        {
            this.transform.position = new Vector3(gnome.transform.position.x-10, gnome.transform.position.y, gnome.transform.position.z);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        //Debug.Log("enter");
        GameObject collided_with = other.gameObject;
        if (collided_with.tag == "Player")
        {
            gnome.GetComponent<EnemyAI>().seen = true;
            BoxCollider2D cc = GetComponent<BoxCollider2D>();
            cc.enabled = false;
            //Debug.Log("Working");
        }
    }
}
