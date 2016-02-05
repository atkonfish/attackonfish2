using UnityEngine;
using System.Collections;

public class enemyAttack : MonoBehaviour {

    // Use this for initialization
    //Defines the location of the gun barrel. This is where the bullet comes out.
   // private GameObject barrel;
    //Defines the bullet for prefab
    public GameObject bullet;
    //Defines a delay for bullets being shot
    public float delayshot = 1f;
   


    private float Timer;



    void Shoot()
   {
       Timer = Time.time + delayshot;
   }

    void Update()
    {
        //barrel.transform.position = new Vector3(-6, 0, 0);
        
        if (Timer < Time.time)
        { 
            Instantiate(bullet, gameObject.transform.position, Quaternion.identity);
            Timer = Time.time + delayshot;

        }
    }

}
