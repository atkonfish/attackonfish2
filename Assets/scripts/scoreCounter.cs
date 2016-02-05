using UnityEngine;
using System.Collections;

public class scoreCounter : MonoBehaviour {
	
	public static int score = 0;
	
	void Update () {
		GetComponent<TextMesh>().text = score.ToString();
	}
}
