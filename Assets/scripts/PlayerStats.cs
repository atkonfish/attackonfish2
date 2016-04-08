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
		this.GetComponent<PolygonCollider2D>().enabled = false;
		yield return new WaitForSeconds (0.2f);
		hit.GetComponentInChildren<RawImage>().enabled = false;
		for (int i = 0; i < 4; i++) {
			this.GetComponent<SpriteRenderer>().color = new Color(1.0f, 1.0f, 1.0f, 0.5f);
			yield return new WaitForSeconds (0.04f);
			this.GetComponent<SpriteRenderer>().color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
			yield return new WaitForSeconds (0.04f);
		}
		this.GetComponent<PolygonCollider2D>().enabled = true;
		this.GetComponent<SpriteRenderer>().color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
	}
}

