using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerHealthUI : MonoBehaviour {
	
	private int health;
	GameObject player;
	private bool check = true;
	private Animator playerAnimator;
	
	void Start () {
		player = GameObject.FindWithTag("player");
		health = player.GetComponentInChildren<PlayerStats>().hp;
		playerAnimator = player.GetComponent<Animator> ();
	}
	
	void Update () {
		health = player.GetComponentInChildren<PlayerStats>().hp;
		GetComponent<Text>().text = "Health: " + health.ToString (); //Player health display
		if (health > 50)
			GetComponent<Text> ().color = Color.green;
		if (health <= 50) {
			GetComponent<Text>().color = new Color(0.8f,0.5f,0.05f);
		}

		if (health <= 25) {
			GetComponent<Text>().color = Color.red;
		}
		if (health < 0 && check) {
			check = false;
			playerAnimator.SetBool ("alive", false);
		}
	}
}
