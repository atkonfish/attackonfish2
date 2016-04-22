using UnityEngine;
using System.Collections;

public class Item : MonoBehaviour {

	public float speed = 5f;
	private GameObject player;
	[SerializeField] private Sprite boost;
	[SerializeField] private Sprite virus;
	private bool swapSprite = false;
	
	void Start () {
		player = GameObject.FindWithTag("player");
		InvokeRepeating("ChangeSprite", 0.25f, 0.25f);
	}
	
	void Update () {
		this.transform.Translate(-speed * Time.deltaTime, 0, 0);

        if(this.transform.position.x < -11)
        {
            Destroy(gameObject);
        }
	}
	
	void OnTriggerEnter2D (Collider2D coll) {
		if (coll.gameObject.tag == "player") {
			Destroy(gameObject);
			player.GetComponentInChildren<PlayerStats>().itemBoost = true;
		}
	}
	
	void ChangeSprite () {
		GetComponent<SpriteRenderer>().sprite = swapSprite ? boost : virus;
		swapSprite = !swapSprite;
	}
}
