using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerHealthUI : MonoBehaviour {
	
	private int health;
	
	void Update () {
		health = Player.hp;
		GetComponent<Text>().text = "Health: " + health.ToString (); //Player health display
		if (health > 50)
			GetComponent<Text> ().color = Color.green;
		if (health <= 50) {
			GetComponent<Text>().color = new Color(0.8f,0.5f,0.05f);
		}

		if (health <= 25) {
			GetComponent<Text>().color = Color.red;
		}
	
	}
}
