using UnityEngine;
using System.Collections;

public class itemMove : MonoBehaviour {

	public float speed = 5f;
	
	// Update is called once per frame
	void Update () {
		this.transform.Translate(-speed * Time.deltaTime, 0, 0);

        if(this.transform.position.x < -11)
        {
            Destroy(gameObject);
        }
	}
}
