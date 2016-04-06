using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class localization {
	
	private static localization instance = null;
	
	public static localization Instance
	{
		get {
			if (instance == null)
			{
				instance = new localization();
			}
			return instance;
		}
	}
	
	
	private List<string> englishList = new List<string>();
	private List<string> chineseList = new List<string>();
	
	
	private localization ()
	{
		//Start Game, index 0
		englishList.Add("Start Game");
		chineseList.Add("開始遊戲");
		//Exit, index 1
		englishList.Add("Exit");
		chineseList.Add("離開");
		//Select Submarine, index 2
		englishList.Add("Select Submarine");
		chineseList.Add("選擇潛艇");
		//Enter Player Name, index 3
		englishList.Add("Enter Player Name");
		chineseList.Add("輸入玩家名字");
		//Score, index 4
		englishList.Add("Score");
		chineseList.Add("分數");
		//Health, index 5
		englishList.Add("Health");
		chineseList.Add("血量");
		//High Scores, index 6
		englishList.Add("High Scores");
		chineseList.Add("最高分");
		//Rank, index 7
		englishList.Add("Rank");
		chineseList.Add("排行");
		//Name, index 8
		englishList.Add("Name");
		chineseList.Add("名字");
		//Main Menu, index 9
		englishList.Add("Main Menu");
		chineseList.Add("主目錄");
		//Reset High Scores, index 10
		englishList.Add("Reset High Scores");
		chineseList.Add("重置最高分");
	}
	
	private string currentLang = "English";  //English or Chinese
	public string CurrentLang{
		get {
			return currentLang;
		}
		set {
			currentLang = value;
		}
	}
	
	public string getPhrase(int num) {
		if (currentLang == "English") {
			return englishList[num];
		} else if (currentLang == "中文") {
			return chineseList[num];
		} else {
			return "";
		}
	} 
	
	
	
	
	
}
