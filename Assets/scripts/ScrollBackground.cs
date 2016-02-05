using UnityEngine;
using System.Collections;

public class ScrollBackground : MonoBehaviour {

    public float speed;
    GameObject Player;
    int Playerhp;
    PlayerHealth PlayerHP;
    private float Timer;
    

	void Start () {
        speed = 0.5f;
        Player = GameObject.FindGameObjectWithTag("player");
        PlayerHP = Player.GetComponent<PlayerHealth>();

       Timer = Time.time + 3;
	}
	
	void Update () {
        Vector2 offset = new Vector2 (Time.time * speed, 0f);
        GetComponent<Renderer>().material.mainTextureOffset = offset;

       	if (PlayerHP.hp <= 0)
        {
            Timer = Time.time + 3;

            if (Timer < Time.time)
            {
                offset = new Vector2(0f, 0f);
            }
        }

    }
}
