using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour {
	
	[SerializeField] private Text startGame;
	[SerializeField] private Text exit;
	[SerializeField] private Text highScores;
	[SerializeField] private Text language;
	
	void Start () {
		startGame.text = localization.Instance.getPhrase(0);
		exit.text = localization.Instance.getPhrase(1);
		highScores.text = localization.Instance.getPhrase(1);
		language.text = localization.Instance.getPhrase(1);;
	}
	
	void Update () {
		startGame.text = localization.Instance.getPhrase(0);
		exit.text = localization.Instance.getPhrase(1);
		highScores.text = localization.Instance.getPhrase(6);
		language.text = (localization.Instance.CurrentLang == "English") ? "中文" : "English";
	}
}
