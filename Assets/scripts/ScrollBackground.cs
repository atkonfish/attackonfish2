using UnityEngine;
using System.Collections;

public class ScrollBackground : MonoBehaviour {

    public float speed;
    private float Timer;
    

	void Start () {
       speed = 0.25f;
       Timer = Time.time + 3;
	}
	
	void Update () {
        Vector2 offset = new Vector2 (Time.time * speed, 0f);
        GetComponent<Renderer>().material.mainTextureOffset = offset;
    }
}
