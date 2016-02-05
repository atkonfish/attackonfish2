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

    public void Exit()
    {
        Application.Quit();
    }
}
