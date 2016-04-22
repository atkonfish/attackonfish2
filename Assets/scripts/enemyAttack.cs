using UnityEngine;
using System.Collections;

public class enemyAttack : MonoBehaviour {

	// Use this for initialization
    //Defines the location of the gun barrel. This is where the bullet comes out.
	// private GameObject barrel;
    //Defines the bullet for prefab
	public GameObject barrel;
	public GameObject bullet;
    //Defines a time between each bullet is fired
    private float fireRate;
   


    void Start () {
		fireRate = Random.Range(0.8f, 1.2f);
	}

	void Update()
	{
		fireRate -= Time.deltaTime;
		if (fireRate < 0)
		{ 
			fireRate = Random.Range(0.8f, 1.2f) * (1 - (Mathf.Log10(bad1hit.attackPower) / 2));
			Instantiate(bullet, barrel.transform.position, Quaternion.identity);
			GetComponent<AudioSource>().Play();
		}
	}

}
