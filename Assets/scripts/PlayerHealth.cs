using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour {

	public int hp = 100;
	// public GameObject enemy;


    //private int enemy = 0;

    void OnTriggerEnter2D(Collider2D coll)
    {

        if (coll.gameObject.tag == "enemyBullet")
        { 
			hp--;
			PlayerHealthUI.health--;
		}

        if (coll.gameObject.tag == "enemy")
        { 
			hp = hp - 4; 
			PlayerHealthUI.health -= 4;
		}

        if (hp <= 0)
        {
			Destroy (gameObject);
			SceneManager.LoadScene ("Main Menu");
        }			

    }
		
}