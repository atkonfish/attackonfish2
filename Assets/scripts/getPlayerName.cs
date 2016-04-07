using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class getPlayerName : MonoBehaviour {
	
	[SerializeField] private InputField playerName;
	
	void Awake () {
		this.enabled = false;
	}
	
	void OnEnable () {
		if (playerName.text != "Enter Player Name" && playerName.text != "輸入玩家名字") {
			HighScore.playerName = playerName.text;
		} else {
			HighScore.playerName = "";
		}
		this.enabled = false;
	}
}