using UnityEngine;
using System.Collections;
 



public class bad1hit : MonoBehaviour {
   public int hp = 2;
   public int hitScore = 50;
   [SerializeField] private GameObject bubble;
   // public GameObject enemy;


    private int enemy = 0;

	void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "playerbullet")

        {
            hp--;
          
        }

        if (coll.gameObject.tag == "player")
        {
            hp = hp - 4;
        }
  
        if (hp <= 0)
        {
			scoreCounter.score += hitScore;
			Destroy(gameObject);
			GameObject bubbleObj = Instantiate (bubble) as GameObject;
			bubbleObj.transform.position = this.transform.position;
            enemy++;
        }
    }
}

