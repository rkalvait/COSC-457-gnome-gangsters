using UnityEngine;
using System.Collections;

public class ParallaxTrees : MonoBehaviour {

	public GameObject[] trees;
	public GameObject blackbar;
	public int nTrees;
	public float width;
	public float depth;

	private GameObject[] objects;
	private Vector3 old_pos;

	void Start() {
		objects = generateForest ();
		old_pos = transform.position;
	}

	// Update is called once per frame
	void Update () {
		foreach (GameObject tree in objects) {
			float delta = transform.position.x - old_pos.x;
			float percent = (tree.transform.position.z - 10) / 10f;
			float x = tree.transform.position.x + (delta * percent * depth);
			if (transform.position.x - x > width/2f) {
				x += width;
			} else if (transform.position.x - x < -width/2f	) {
				x -= width;
			}
			float y = tree.transform.position.y;
			float z = tree.transform.position.z;

			tree.transform.position = new Vector3(x,y,z);
		}
		blackbar.transform.position = new Vector3 (transform.position.x, blackbar.transform.position.y, blackbar.transform.position.z);
		old_pos = transform.position;
	}

	private GameObject[] generateForest() {
		GameObject[] ret = new GameObject[nTrees];

		for (int i=0; i<ret.Length; i++) {
			float z = Random.Range(10,20);
			float x = Random.Range(-width/2, width/2);// * (1 - (depth * (z-10)/10f));
			GameObject tree = Instantiate(trees[(int)Mathf.Floor( Random.Range (0f,-0.001f + trees.Length))]);
			float y = tree.transform.position.y;

			tree.transform.position = new Vector3(x,y,z);
			float value = (10+(19-z))/20f;
			value = value*value*value;
			tree.GetComponent<SpriteRenderer>().color = new Color( value, value, value );

			float direction = Mathf.Floor( Random.Range (0f, 1.999f));
			tree.transform.localScale = new Vector3(-1 + (2 * direction), 1, 1);

			ret[i] = tree;
		}

		return ret;
	}
}
