using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerHealthUI : MonoBehaviour {
	
	public static int health = 100;

	void Awake (){
		health = 100;
		GetComponent<Text> ().color = Color.green;
	}
	void Update () {
		
		GetComponent<Text>().text = "Health: " + health.ToString (); //Player health display

		if (health <= 50) {
			GetComponent<Text>().color = new Color(0.8f,0.5f,0.05f);
		}

		if (health <= 25) {
			GetComponent<Text>().color = Color.red;
		}
	
	}
}
