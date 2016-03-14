using UnityEngine;
using System.Collections;
 



public class bad1hit : MonoBehaviour {
   public int hp = 2;
   public int hitScore = 50;
   [SerializeField] private Animator death;
   // public GameObject enemy;


    private int enemy = 0;

	void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "playerbullet")
        {
            hp--;
          
        }
		if (coll.gameObject.tag == "playerbulletstrong")

        {
            hp -= 10;
          
        }
        if (coll.gameObject.tag == "player")
        {
            hp = hp - 4;
        }
  
        if (hp <= 0)
        {
			scoreCounter.score += hitScore;
			GetComponent<bad1Movement>().enabled = false;
			death.SetTrigger("Death");
            enemy++;
        }
    }
	
	private void DestroyMe () {
		Destroy(gameObject);
	}
}

