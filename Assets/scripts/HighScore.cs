using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System.IO;

public class HighScore : MonoBehaviour {
	
	//Current player name
	public static string playerName;
	//Display text
	[SerializeField] private Text highScore;
	[SerializeField] private Text rank;
	[SerializeField] private Text name;
	[SerializeField] private Text score;
	[SerializeField] private Text mainMenu;
	[SerializeField] private Text resetScore;
	[SerializeField] private Text nameOne;
	[SerializeField] private Text nameTwo;
	[SerializeField] private Text nameThree;
	[SerializeField] private Text scoreOne;
	[SerializeField] private Text scoreTwo;
	[SerializeField] private Text scoreThree;
	
	void Start () {
		highScore.text = localization.Instance.getPhrase(6);
		rank.text = localization.Instance.getPhrase(7);
		name.text = localization.Instance.getPhrase(8);
		score.text = localization.Instance.getPhrase(4);
		mainMenu.text = localization.Instance.getPhrase(9);
		resetScore.text = localization.Instance.getPhrase(10);
		updateRanking ();
	}
	
	void Update () {
		//Display ranking info
		nameOne.text = PlayerPrefs.GetString("1stPlayerName");
		scoreOne.text = (PlayerPrefs.GetInt("1stPlayerScore") > 0) ? PlayerPrefs.GetInt("1stPlayerScore").ToString() : "";
		nameTwo.text = PlayerPrefs.GetString("2ndPlayerName");
		scoreTwo.text = (PlayerPrefs.GetInt("2ndPlayerScore") > 0) ? PlayerPrefs.GetInt("2ndPlayerScore").ToString() : "";
		nameThree.text = PlayerPrefs.GetString("3rdPlayerName");
		scoreThree.text = (PlayerPrefs.GetInt("3rdPlayerScore") > 0) ? PlayerPrefs.GetInt("3rdPlayerScore").ToString() : "";
	}
	
	void updateRanking () {
		int newScore = scoreCounter.score;
		int highestScore = PlayerPrefs.GetInt("1stPlayerScore");
		int secondHighestScore = PlayerPrefs.GetInt("2ndPlayerScore");
		int thirdHighestScore = PlayerPrefs.GetInt("3rdPlayerScore");
		string holder;
		//Test new score against 3rd place, if new score is higher store into 3rd place
		if (newScore > thirdHighestScore) {
			PlayerPrefs.SetInt("3rdPlayerScore", newScore);
			PlayerPrefs.SetString("3rdPlayerName", playerName);
			//Test new score against 2nd place, if new score is higher, move 2nd place to 3rd place and store into 2nd place
			if (newScore > secondHighestScore) {
				PlayerPrefs.SetInt("3rdPlayerScore", secondHighestScore);
				PlayerPrefs.SetString("3rdPlayerName", PlayerPrefs.GetString("2ndPlayerName"));
				PlayerPrefs.SetInt("2ndPlayerScore", newScore);
				PlayerPrefs.SetString("2ndPlayerName", playerName);
				//Test new score against 1st place, if new score is higher, move 1st place to 2nd place and store into 1st place
				if (newScore > highestScore) {
					PlayerPrefs.SetInt("2ndPlayerScore", highestScore);
					PlayerPrefs.SetString("2ndPlayerName", PlayerPrefs.GetString("1stPlayerName"));
					PlayerPrefs.SetInt("1stPlayerScore", newScore);
					PlayerPrefs.SetString("1stPlayerName", playerName);
				}
			}
		}
	}
}
