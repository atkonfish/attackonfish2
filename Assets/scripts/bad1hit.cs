using UnityEngine;
using System.Collections;
 



public class bad1hit : MonoBehaviour {
   public int hp = 2;
   public int hitScore = 50;
   public static int attackPower = 1;
   [SerializeField] private Animator death;

    private int enemy = 0;

	void Update(){
		if (hp <= 0) {
			GetComponent<bad1Movement> ().enabled = false;
			GetComponent<PolygonCollider2D> ().enabled = false;
			death.SetTrigger ("Death");
			enemy++;
		}
	}
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
    }
	
	private void DestroyMe () {
		
		Destroy(gameObject);
	}

	private void ScoreUpdate(){
		scoreCounter.score += hitScore;
	}
}

