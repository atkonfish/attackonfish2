using UnityEngine;
using System.Collections;

public class boss1 : MonoBehaviour {
	
	private int hp;
	private int initHP;
	[SerializeField] private GameObject bulletPrefab;
	//All boss movement controlled by animater
	[SerializeField] private Animator bossControl;
	//Boss movement variables
	private bool isIdle;
	private bool isRage; //Rage mode boolean
	private int attackPattern; //0 for free roam, integers from 1 to numOfAttacks-1 each represent a different attack pattern
	const int numOfAttacks = 3;
	
	
	void Start () {
		initHP = 200;
		hp = initHP;
		isIdle = false;
		isRage = false;
	}
	
	
	void Update () {
		hpCheck();
		if(isIdle && !isRage) {
			isIdle = false;
			//Cannot preform 2 free roam actions consecutively
			if (attackPattern == 0) {
				attackPattern = Random.Range(1, numOfAttacks);
			} else {
				attackPattern = Random.Range(0, numOfAttacks);
			}
			StartCoroutine(action ());
		} else if (isIdle && isRage) {
			isIdle = false;
			//No more free roam during rage
			attackPattern = Random.Range(1, numOfAttacks);
			StartCoroutine(action ());
		}
	}
	
	void OnTriggerEnter2D (Collider2D coll) {
        if (coll.gameObject.tag == "playerbullet") {
			hp--;
		} else if (coll.gameObject.tag == "playerbulletstrong") {
			hp = hp - 10;
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
	
	void setIdel () {
		isIdle = true;
		bossControl.SetTrigger("Idle");
	}
	
	private IEnumerator action () {
		//Wait 1s between actions if not in rage mode
		if (!isRage)
			yield return new WaitForSeconds(1.0f);
		if (attackPattern == 0) 
			bossControl.SetTrigger("Roam");
		else if (attackPattern == 1)
				bossControl.SetTrigger("Attack1");
		else if (attackPattern == 2)
				bossControl.SetTrigger("Attack2");
	}
	
	IEnumerator attack1 () {
		//Randomize clockwise/counterclockwise firing
		int clock = Random.Range(0, 2) * 2 - 1;
		if (!isRage) {
			//Fire a ring of projectiles, wide gap
			for (int i = 0; i <= 360; i = i + 20) {
				yield return new WaitForSeconds(0.1f);
				Instantiate(bulletPrefab, this.transform.position, Quaternion.Euler(0, 0, i * clock));
			}
		} else {
			//Fire 2 rings of projectiles, narrow gap 
			for (int i = 0; i <= 720; i = i + 10) {
				yield return new WaitForSeconds(0.025f);
				Instantiate(bulletPrefab, this.transform.position, Quaternion.Euler(0, 0, i * clock));
			}
		}
	}
	
	void attack2 () {
		//Aim at player
		GameObject player;
		player = GameObject.FindWithTag("player");
		Vector3 posPlayer = player.transform.position;
		Vector3 posSelf = this.transform.position;
		float angle = Vector3.Angle(Vector3.left, (posPlayer - posSelf));
		if (!isRage) {
			//Fire 1 projectile
			if (posPlayer.y >= posSelf.y)
				Instantiate(bulletPrefab, this.transform.position, Quaternion.Euler(0, 0, -angle));
			else 
				Instantiate(bulletPrefab, this.transform.position, Quaternion.Euler(0, 0, angle));
		} else {
			//Fire 3 projectiles at once
			if (posPlayer.y >= posSelf.y) {
				Instantiate(bulletPrefab, this.transform.position, Quaternion.Euler(0, 0, -angle));
				Instantiate(bulletPrefab, this.transform.position, Quaternion.Euler(0, 0, -angle + 10));
				Instantiate(bulletPrefab, this.transform.position, Quaternion.Euler(0, 0, -angle - 10));
			} else {
				Instantiate(bulletPrefab, this.transform.position, Quaternion.Euler(0, 0, angle));
				Instantiate(bulletPrefab, this.transform.position, Quaternion.Euler(0, 0, angle + 10));
				Instantiate(bulletPrefab, this.transform.position, Quaternion.Euler(0, 0, angle - 10));
			}		
		}
	}
}
