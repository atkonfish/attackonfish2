using UnityEngine;
using System.Collections;

public class waitDestroy : MonoBehaviour {
	// just set a 0.5sec delay before destroy the game object.

	public float time = 1f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		StartCoroutine (wait ());
	}
	private IEnumerator wait(){
		yield return new WaitForSeconds (time);
		Destroy (this.gameObject);
	}
}
