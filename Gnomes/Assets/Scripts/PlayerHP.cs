using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerHP : MonoBehaviour {
	public int startingHP = 100;
	public int currentHP;
	Color FullHP = Color.green;
	Color NoHP = Color.red;
	public Image Fill;
	Slider healthSlider;
	// Use this for initialization
	void Start () {
		currentHP = startingHP;
		healthSlider = GameObject.Find ("HealthSlider").GetComponent<Slider> ();
		//Fill = GameObject.Find ("HealthSlider").GetComponent<Slider> ().;
	}
	
	// Update is called once per frame
	void Update () {
		if (currentHP <= 0) {
			currentHP = 0;
		}
		healthSlider.value = currentHP;
		Fill.color = Color.Lerp (NoHP, FullHP, (float)currentHP / startingHP);
		if (currentHP == 0) {
			Fill.color = Color.black;
		}
	}

	void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.tag == "Bullet") {
			currentHP -= 10;
		}
		if (collision.tag == "Impossibru") {
			currentHP -= 5;
		}
		if (currentHP <= 0) {
			Debug.Log("You are dead!");
			playerDeath();
		}
	}

	void playerDeath()
	{

	}
}
