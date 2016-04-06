using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerHealthUI : MonoBehaviour {
	
	private int health;
	GameObject player;
	
	void Start () {
		player = GameObject.FindWithTag("player");
		health = player.GetComponentInChildren<PlayerStats>().hp;
	}
	
	void Update () {
		health = player.GetComponentInChildren<PlayerStats>().hp;
		GetComponent<Text>().text = localization.Instance.getPhrase(5) + ": " + health.ToString (); //Player health display
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
