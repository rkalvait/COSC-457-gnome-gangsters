using UnityEngine;
using System.Collections;

//Works for the things attached to the player as well
public class CameraController : MonoBehaviour
{

    public GameObject player;
	public float smoothing;

    private Vector3 offset;

    // Use this for initialization
    void Start()
    {
        offset = transform.position - player.transform.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        
        transform.position = Vector3.Lerp(transform.position, player.transform.position + offset, smoothing);
        
    }
}
