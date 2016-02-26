using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class getPlayerName : MonoBehaviour {
	
	[SerializeField] private InputField playerName;
	
	void Awake () {
		this.enabled = false;
	}
	
	void OnEnable () {
		HighScore.playerName = playerName.text;
		this.enabled = false;
	}
	
}