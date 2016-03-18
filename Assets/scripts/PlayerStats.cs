using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour {

	public int hp;
    public bool itemBoost = false;
	public bool virusBoost = false;
	
	//Screen flash when player is hit
	public GameObject hit;

	public IEnumerator Flash(){
		hit.GetComponentInChildren<RawImage>().enabled = true;
		Debug.Log ("hit");
		yield return new WaitForSeconds (0.2f);
		hit.GetComponentInChildren<RawImage>().enabled = false;
	}
}

