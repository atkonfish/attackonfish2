using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System.IO;

public class HighScore : MonoBehaviour {
	
	//
	public static string playerName;
	//Reading txt file
	[SerializeField] private TextAsset textFile;
	private string wholeFile;
	private List<string> eachLine;
	//Display text
	[SerializeField] private Text highScore;
	[SerializeField] private Text rank;
	[SerializeField] private Text name;
	[SerializeField] private Text score;
	[SerializeField] private Text mainMenu;
	[SerializeField] private Text nameOne;
	[SerializeField] private Text nameTwo;
	[SerializeField] private Text nameThree;
	[SerializeField] private Text scoreOne;
	[SerializeField] private Text scoreTwo;
	[SerializeField] private Text scoreThree;
	
	bool rewriteFile = false;
	StreamWriter sw;
	
	
	void Start () {
		highScore.text = localization.Instance.getPhrase(6);
		rank.text = localization.Instance.getPhrase(7);
		name.text = localization.Instance.getPhrase(8);
		score.text = localization.Instance.getPhrase(4);
		mainMenu.text = localization.Instance.getPhrase(9);
		//Reads whole file as one string
		wholeFile = textFile.text;
		//Split each line into shorter strings with newline character
		//2 lines per entry, 1st line for name, 2nd line for score
		eachLine = new List<string>();
		eachLine.AddRange(wholeFile.Split("\n"[0]) );
		//Test new highscore
		updateRanking();
		//Display ranking info
		nameOne.text = eachLine[0];
		scoreOne.text = eachLine[1];
		nameTwo.text = eachLine[2];
		scoreTwo.text = eachLine[3];
		nameThree.text = eachLine[4];
		scoreThree.text = eachLine[5];
		if (rewriteFile) {
			sw = new StreamWriter(Application.dataPath + "/txt_Files/" +"highscores.txt");
			sw.WriteLine(eachLine[0]);
			sw.WriteLine(eachLine[1]);
			sw.WriteLine(eachLine[2]);
			sw.WriteLine(eachLine[3]);
			sw.WriteLine(eachLine[4]);
			sw.WriteLine(eachLine[5]);
			sw.Close();
		}
	}
	
	void updateRanking () {
		int newScore = scoreCounter.score;
		int tempScoreOne = int.Parse(eachLine[1]);
		int tempScoreTwo = int.Parse(eachLine[3]);
		int tempScoreThree = int.Parse(eachLine[5]);
		string holder;
		//Test new score against 3rd place
		if (newScore > tempScoreThree) {
			rewriteFile = true; //Trigger to update new highscore.txt
			eachLine[5] = newScore.ToString(); //Replace 3rd place with new score
			eachLine[4] = playerName;
			//Test new score against 2nd place
			if (newScore > tempScoreTwo) {
				holder = eachLine[5]; //Replace 2nd place with new score
				eachLine[5] = eachLine[3];
				eachLine[3] = holder;
				holder = eachLine[4];
				eachLine[4] = eachLine[2];
				eachLine[2] = holder;
				//Test new score against 1st place
				if (newScore > tempScoreOne) {
					holder = eachLine[3]; //Replace 1st place with new score
					eachLine[3] = eachLine[1];
					eachLine[1] = holder;
					holder = eachLine[2];
					eachLine[2] = eachLine[0];
					eachLine[0] = holder;
				}
			}
		}
	}
}
