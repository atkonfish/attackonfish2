using UnityEngine;
using System.Collections;

public class playerShoot : MonoBehaviour
{

    //Defines the location of the gun barrel. This is where the bullet comes out.
    public GameObject barrel;
    //Defines the bullet for prefab
    public GameObject bullet;
    //Defines a delay for bullets being shot
    float delayshot = 0.25f;
    //Defines the cool down time for the delay
    float coolDown = 0;

    public static bool itemBoost = false;
    float boostDuration;

    void Start()
    {
        boostDuration = 5.0f;
    }

    void Update()
    {
        coolDown -= Time.deltaTime;
        //single shot
		if (Input.GetKey(KeyCode.A) && coolDown <= 0 && !itemBoost)
        {
            coolDown = delayshot;
            //Creates a bullet from the position of the gun barrel.
            Instantiate(bullet, barrel.transform.position, Quaternion.identity);
			GetComponent<AudioSource> ().Play ();
        }
		//3 burst shot
        if (Input.GetKey(KeyCode.A) && coolDown <= 0 && itemBoost)
        {
            coolDown = delayshot;
            Instantiate(bullet, barrel.transform.position, Quaternion.Euler(0, 0, 0));
            Instantiate(bullet, barrel.transform.position, Quaternion.Euler(0, 0, 10));
            Instantiate(bullet, barrel.transform.position, Quaternion.Euler(0, 0, -10));
			GetComponent<AudioSource> ().Play ();
        }

		//Shooting Sound
		/*if (Input.GetKeyDown ("a")) {
			keydown = true;
			if (keydown = true) {
				
				if (Input.GetKeyUp ("a")) {
					GetComponent<AudioSource> ().Stop ();
				}
			}
		}*/

        if (itemBoost)
        {
            boostDuration -= Time.deltaTime;
            if (boostDuration <= 0)
            {
                itemBoost = false;
                boostDuration = 5.0f;
            }
        }
    }

}

