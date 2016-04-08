using UnityEngine;
using System.Collections;

public class bubble : MonoBehaviour {
	public float speed;
	private float delayTime = 1;
	private bool move = true;

	private Animator bubbleAnimator;

	// Use this for initialization
	void Start () {
		bubbleAnimator = GetComponent<Animator> ();
		StartCoroutine (delay ());
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate (0, speed * Time.deltaTime, 0);
		if (move) {
			bubbleAnimator.SetBool ("end", true);
			transform.Translate (0, speed * 0.5f * Time.deltaTime, 0);
			StartCoroutine (delay ());
		}
	}

	private IEnumerator delay(){
		yield return new WaitForSeconds (delayTime);
		if (!move) {
			Destroy (this.gameObject);
		}
		move = false;
	}
}
