using UnityEngine;
using System.Collections;

public class itemCollide : MonoBehaviour {

	void OnTriggerEnter2D (Collider2D coll) {
		if (coll.gameObject.tag == "player") {
			Destroy(gameObject);
			Player.itemBoost = true;
		}
	}
}
