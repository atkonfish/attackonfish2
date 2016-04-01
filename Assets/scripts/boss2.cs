using UnityEngine;
using System.Collections;

public class boss2 : MonoBehaviour {

	private int hp;
	private int initHP;
	[SerializeField] private float speed = 10f;
	[SerializeField] private GameObject bulletPrefab;
	//Boss movement variables
	private Vector3 idlePosition;
	private bool isIdle;
	private bool movingToIdle;
	private bool isRage; //Rage mode boolean
	private int attackPattern; //Integers from 1 to numOfAttacks-1 each represent a different attack pattern
	const int numOfAttacks = 3;
	
	void Start () {
		initHP = 200;
		hp = initHP;
		isIdle = false;
		movingToIdle = true;
		isRage = false;
		idlePosition = new Vector3 (0, 0, 0);
	}
	
	void Update () {
		hpCheck ();
		if (isIdle) {
			isIdle = false;
			attackPattern = Random.Range(1, numOfAttacks);
			if (attackPattern == 1) {
				StartCoroutine(attack1 ());
			} else if (attackPattern == 2) {
				StartCoroutine(attack2 ());
			} else if (attackPattern == 3) {
				
			}
		} else if (movingToIdle) {
			MoveToIdlePosition ();
		}
	}
	
	void hpCheck () {
		//Boss goes into rage mode if hp less than 50%
		if (hp < 0.5 * initHP)
			isRage = true;
		if (hp < 0) {
			scoreCounter.score += 2000;
			Destroy(gameObject);
			SpawnEnemy.spawningCheck = true;
		}
	}
	
	void MoveToIdlePosition () {
		Vector3 direc = Vector3.Normalize(idlePosition - this.transform.position);
		transform.Translate(direc * speed * Time.deltaTime);
		if (Mathf.Abs(this.transform.position.x) < 0.1 && Mathf.Abs(this.transform.position.y) < 0.1 && Mathf.Abs(this.transform.position.z) < 0.1) {
			this.transform.position = idlePosition;
			isIdle = true;
			movingToIdle = false;
		}
	}
	
	IEnumerator attack1 () {
		//Teleport to random location and shoot a ring of bullets
		yield return new WaitForSeconds(0.5f);
		int times;
		float breakGap;
		if (isRage) {
			times = 10; //number of telepots
			breakGap = 0.5f; //time boss takes between teleports
		} else {
			times = 5; //number of telepots
			breakGap = 1.5f; //time boss takes between teleports
		}
		for (int i = 0; i < times; i++) {
			float posX = Random.Range(-8.6f, 8.6f);
			float posY = Random.Range(-3f, 3f);
			int clock = Random.Range(0, 2) * 2 - 1;
			this.transform.position = new Vector3 (posX, posY, 0);
			for (int j = 0; j <= 360; j = j + 20) {
				yield return new WaitForSeconds(0.025f);
				Instantiate(bulletPrefab, this.transform.position, Quaternion.Euler(0, 0, j * clock));
			}
			yield return new WaitForSeconds(breakGap);
		}
		movingToIdle = true;
	}
	
	IEnumerator attack2 () {
		//Chase player
		GameObject player;
		player = GameObject.FindWithTag("player");
		yield return new WaitForSeconds(0.5f);
		int time;
		int breakGap;
		if (isRage) {
			time = 200; //time/40 is the actual time in seconds
			breakGap = 10; //smaller value corrisponds to boss pausing more often
		} else {
			time = 120; //time/40 is the actual time in seconds
			breakGap = 7; //smaller value corrisponds to boss pausing more often
		}
		for (int i = 0; i < time; i++) {
			Vector3 posPlayer = player.transform.position;
			Vector3 posSelf = this.transform.position;
			Vector3 direc = ((posPlayer - posSelf).magnitude < 1) ? (posPlayer - posSelf) : Vector3.Normalize(posPlayer - posSelf);
			yield return new WaitForSeconds(0.025f);
			transform.Translate(direc / 3);
			if (i%breakGap == 0)
				yield return new WaitForSeconds(0.5f);
		}
		movingToIdle = true;
	}
	
	void OnTriggerEnter2D (Collider2D coll) {
        if (coll.gameObject.tag == "playerbullet") {
			hp--;
		} else if (coll.gameObject.tag == "playerbulletstrong") {
			hp = hp - 10;
		}
	}
}


