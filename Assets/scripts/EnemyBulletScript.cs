using UnityEngine;
using System.Collections;

public class EnemyBulletScript : MonoBehaviour {

    //Define the speed of the bullet.
    float speed = 25f;

    void Update()
    {
        //Defined to get width of main camera.
        // float screenRatio = (float)Screen.width / (float)Screen.height;
        //float widthOrtho = Camera.main.orthographicSize * screenRatio;

        //Moves bullet across the screen.
        Vector3 pos = transform.position;
        Vector3 velocity = new Vector3(speed * Time.deltaTime, 0, 0);

        //this.transform.Translate(speed * Time.deltaTime, 0, 0);

         pos -= transform.rotation * velocity;

        transform.position = pos;

        // if (pos.x > widthOrtho)
        if (this.transform.position.x < -11)
            {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "player")
            Destroy(gameObject);
    }
}
