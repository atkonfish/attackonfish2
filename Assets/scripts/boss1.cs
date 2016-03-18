using UnityEngine;
using System.Collections;

public class boss1 : MonoBehaviour {
	
	private int hp;
	[SerializeField] private GameObject bulletPrefab;
	[SerializeField] private Animator bossControl;
	private bool isIdle;
	private bool isRage;
	private int attackPattern;
	const int numOfAttacks = 3;
	
	
	void Start () {
		hp = 200;
		isIdle = false;
		isRage = false;
	}
	
	
	void Update () {
		hpCheck();
		if(isIdle && !isRage) {
			isIdle = false;
			if (attackPattern == 0) {
				attackPattern = Random.Range(1, numOfAttacks);
			} else {
				attackPattern = Random.Range(0, numOfAttacks);
			}
			StartCoroutine(action ());
		} else if (isIdle && isRage) {
			isIdle = false;
			attackPattern = Random.Range(1, numOfAttacks);
			StartCoroutine(action ());
		}
	}
	
	void OnTriggerEnter2D (Collider2D coll) {
        if (coll.gameObject.tag == "playerbullet")
			hp--;
		else if (coll.gameObject.tag == "playerbulletstrong")
			hp = hp - 10;
	}
	
	void hpCheck () {
		if (hp < 100)
			isRage = true;
		if (hp < 0)
			Destroy(gameObject);
	}
	
	void setIdel () {
		isIdle = true;
		bossControl.SetTrigger("Idle");
	}
	
	private IEnumerator action () {
		yield return new WaitForSeconds(1.0f);
		if (attackPattern == 0) 
			bossControl.SetTrigger("Roam");
		else if (attackPattern == 1)
				bossControl.SetTrigger("Attack1");
		else if (attackPattern == 2)
				bossControl.SetTrigger("Attack2");
	}
	
	IEnumerator attack1 () {
		int clock = Random.Range(0, 2) * 2 - 1;
		if (!isRage) {
			for (int i = 0; i <= 360; i = i + 20) {
				yield return new WaitForSeconds(0.1f);
				Instantiate(bulletPrefab, this.transform.position, Quaternion.Euler(0, 0, i * clock));
			}
		} else {
			for (int i = 0; i <= 720; i = i + 20) {
				yield return new WaitForSeconds(0.05f);
				Instantiate(bulletPrefab, this.transform.position, Quaternion.Euler(0, 0, i * clock));
			}
		}
	}
	
	void attack2 () {
		GameObject player;
		player = GameObject.FindWithTag("player");
		Vector3 posPlayer = player.transform.position;
		Vector3 posSelf = this.transform.position;
		float angle = Vector3.Angle(Vector3.left, (posPlayer - posSelf));
		if (!isRage) {
			if (posPlayer.y >= posSelf.y)
				Instantiate(bulletPrefab, this.transform.position, Quaternion.Euler(0, 0, -angle));
			else 
				Instantiate(bulletPrefab, this.transform.position, Quaternion.Euler(0, 0, angle));
		} else {
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
