using UnityEngine;
using System.Collections;

public class Bulletout : MonoBehaviour {
	bool keydown = false;
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown ("a")) {
			keydown = true;
			if (keydown = true) {
				GetComponent<AudioSource> ().Play ();
				if (Input.GetKeyUp ("a")) {
					GetComponent<AudioSource> ().Stop ();
				}
			}
		}
	}
}