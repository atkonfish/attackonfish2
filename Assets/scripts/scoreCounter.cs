using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class scoreCounter : MonoBehaviour {
	
	public static int score = 0;

	void Awake(){
		score = 0;
	}
	void Update () {
		GetComponent<Text>().text = localization.Instance.getPhrase(4) + ": " + score.ToString();
	}
}
