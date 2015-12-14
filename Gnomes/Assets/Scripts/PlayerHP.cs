using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerHP : MonoBehaviour {
	public int startingHP = 100;
	public int currentHP;
	Color FullHP = Color.green;
	Color NoHP = Color.red;
	public Image Fill;
	public Image ScreenFade;
	public Text text;
	Slider healthSlider;
    AudioSource audio;
	bool dead;
	// Use this for initialization
	void Start () {
		currentHP = startingHP;
		healthSlider = GameObject.Find ("HealthSlider").GetComponent<Slider> ();
		dead = false;
        audio = GetComponent<AudioSource>();
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
		if (dead) {
			if(Input.GetButtonDown("Fire1"))
			{
				Application.LoadLevel("_Scene_ManScreen");
			}
		}
	}

	void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.tag == "Bullet") {
			currentHP -= 10;
            if(!dead)
                audio.Play();
		} else if (collision.tag == "Dorito") {
			currentHP -= 10;
		} else if (collision.tag == "Impossibru") {
			currentHP -= 5;
		} else if (collision.tag == "Doge") {
			currentHP -= 7;
		}


		if (currentHP <= 0) {
			Debug.Log("You are dead!");
			playerDeath();
		}
	}

	void playerDeath()
	{
		text.color = new Color (1, 0, 0, 1);
		ScreenFade.color = new Color (0, 0, 1, 1);
		dead = true;

	}
}
