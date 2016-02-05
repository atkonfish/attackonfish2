using UnityEngine;
using System.Collections;

public class PlayerHealth : MonoBehaviour {

    public int hp = 100;
   // public GameObject enemy;


    //private int enemy = 0;

    void OnTriggerEnter2D(Collider2D coll)
    {

        if (coll.gameObject.tag == "enemybullet")
        { hp--; }

        if (coll.gameObject.tag == "enemy")
        { hp = hp - 4; }

        if (hp <= 0)
        {
            Destroy(gameObject);
        }

    }
}