using UnityEngine;
using System.Collections;

public class HPrecovery : MonoBehaviour {

	public float speed = 5f;
	GameObject player;
	
	void Start () {
		player = GameObject.FindWithTag("player");
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
			player.GetComponentInChildren<PlayerStats>().hp += 30;
		}
	}
}
