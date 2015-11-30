using UnityEngine;
using System.Collections;

public class ParallaxTrees : MonoBehaviour {

	public GameObject[] trees;
	public int nTrees;
	public float width;

	private GameObject[] objects;

	void Start() {
		objects = generateForest ();
	}

	// Update is called once per frame
	void Update () {

	}

	private GameObject[] generateForest() {
		GameObject[] ret = new GameObject[nTrees];

		for (int i=0; i<ret.Length; i++) {
			float x = Random.Range(-width/2, width/2);
			float z = Random.Range(10,20);
			GameObject tree = Instantiate(trees[(int)Mathf.Floor( Random.Range (0f,-0.001f + trees.Length))]);
			float y = tree.transform.position.y;

			tree.transform.position = new Vector3(x,y,z);
			tree.GetComponent<SpriteRenderer>().color = new Color(256 - ((z-10)/20*256), 256 - ((z-10)/20*256), 256 - ((z-10)/20*256) );

			ret[i] = tree;
		}

		return ret;
	}
}
