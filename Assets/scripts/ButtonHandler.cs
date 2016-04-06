using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ButtonHandler : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void LoadScene(string sceneName) {
        SceneManager.LoadScene(sceneName); 
    }

	public void LoadPlay(int Num) {
		this.GetComponent<getPlayerName> ().enabled = true;
		spawnPlayer.spawnNum = Num;
	}
	
	public void ChangeLang() {
		localization.Instance.CurrentLang = (localization.Instance.CurrentLang == "English") ? "中文" : "English";
	}

	public void Exit()
    {
        Application.Quit();
    }
}
