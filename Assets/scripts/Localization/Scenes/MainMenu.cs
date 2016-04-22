using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour {
	
	[SerializeField] private Text startGame;
	[SerializeField] private Text exit;
	[SerializeField] private Text highScores;
	[SerializeField] private Text language;
	[SerializeField] private Text controls;
	[SerializeField] private Text credits;
	
	void Start () {
		startGame.text = localization.Instance.getPhrase(0);
		exit.text = localization.Instance.getPhrase(1);
		highScores.text = localization.Instance.getPhrase(1);
		language.text = localization.Instance.getPhrase(1);
		controls.text = localization.Instance.getPhrase(12);
		credits.text = localization.Instance.getPhrase(11);
		//Reset player name and score when scene is loaded
		scoreCounter.score = 0;
		HighScore.playerName = "";
	}
	
	void Update () {
		startGame.text = localization.Instance.getPhrase(0);
		exit.text = localization.Instance.getPhrase(1);
		highScores.text = localization.Instance.getPhrase(6);
		controls.text = localization.Instance.getPhrase(12);
		credits.text = localization.Instance.getPhrase(11);
		language.text = (localization.Instance.CurrentLang == "English") ? "中文" : "English";
	}
}
