using UnityEngine;
using System.Collections;

public class EnemyBulletScript : MonoBehaviour {

    //Define the speed of the bullet.
    float speed = 25f;
	float widthOrtho;
	
	void Start () {
		//Defined to get width of main camera.
        float screenRatio = (float)Screen.width / (float)Screen.height;
        widthOrtho = Camera.main.orthographicSize * screenRatio;
	}
	
    void Update()
    {
        //Moves bullet across the screen.
        transform.Translate(Vector3.left * speed * Time.deltaTime);
		Vector3 pos = transform.position;
        if(pos.x > widthOrtho || pos.x < -widthOrtho || pos.y > Camera.main.orthographicSize || pos.y < -Camera.main.orthographicSize)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "player")
            Destroy(gameObject);
		if (coll.gameObject.tag == "playerbulletstrong")
            Destroy(gameObject);
    }
}
