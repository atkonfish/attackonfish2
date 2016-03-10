using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class gameOver : MonoBehaviour {

	public float loadTime = 3f;
	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		StartCoroutine (load ());

	}

	private IEnumerator load(){
		yield return new WaitForSeconds (loadTime);
		SceneManager.LoadScene ("High Scores");
	}
}