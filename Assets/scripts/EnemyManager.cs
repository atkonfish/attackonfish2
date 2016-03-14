using UnityEngine;
using System.Collections;

public class EnemyManager : MonoBehaviour
{
    // The enemy prefab to be spawned.

    private GameObject spawn;
    public GameObject enemy;
    // Transform spawn;
    public float spawnTime = 3f;
    // public Transform[] spawn;

    public GameObject barrel;


    private float Timer;

    /* void Start()
     {
         for (int i = 0; i < 10; i++)
         {
             Instantiate(prefab, new Vector3(i * 2.0F, 0, 0), Quaternion.identity);
         }
     }*/

    /*void Awake()
    {
        Timer = Time.time + 3;
    }*/

    public void Parent()
    {
        barrel.transform.parent = enemy.transform;
    }
   

    void Start()
    {

        // Call the Spawn function after a delay of the spawnTime and then continue to call after the same amount of time.
        InvokeRepeating("Spawn", spawnTime, spawnTime);
    }



    // Update is called once per frame
    void Spawn()
    {

        if (enemy == null)
        {
            /* enemy = Instantiate(spawn) as GameObject;

          }*/

            // if (Timer < Time.time)
            //{
            float spawnY = Random.Range(-4.2f, 4.2f);
            // enemy = Instantiate(spawn) as GameObject;
            //Instantiate(prefab, new Vector3(10, spawnY, 0), Quaternion.identity);
            // gameObject.transform.position = new Vector3(10, spawnY, 0); 
            // Rigidbody clone;
            //clone = Instantiate(gameObject, transform.position, transform.rotation);
            spawn = (GameObject)Instantiate(enemy, new Vector3(10, spawnY, 0), Quaternion.identity);

            /* if (spawn == null)
             {
                 spawn = Instantiate(gameObject, new Vector3(10, spawnY, 0), Quaternion.identity) as GameObject;
             }*/
            //  Timer = Time.time + 3;
            //}
        }
    }
}