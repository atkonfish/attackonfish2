using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class scoreCounter : MonoBehaviour {
	
	public static int score = 0;

	void Awake(){
		score = 0;
	}
	void Update () {
		//GetComponent<TextMesh>().text ="Score: " + score.ToString();
		GetComponent<Text>().text = "Score: " + score.ToString();
	}
}
