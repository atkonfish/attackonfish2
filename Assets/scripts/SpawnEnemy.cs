using UnityEngine;
using System.Collections;

public class SpawnEnemy : MonoBehaviour {
   
	[SerializeField] public GameObject enemyPrefab;
	private GameObject _enemy;
    public float spawnTime = 3f;
    GameObject Player;
    int Playerhp;
    PlayerHealth PlayerHealthScript;
    bool spawningCheck = true;


    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("player");
        PlayerHealthScript = Player.GetComponent<PlayerHealth>();


        if (spawningCheck)
        {
            InvokeRepeating("Spawn", spawnTime, spawnTime);
        }

        

       // if (PlayerHealthScript.hp > 0)
        //{
           // InvokeRepeating("Spawn", spawnTime, spawnTime);
        //}
    }

    void Update()

    {
        if (spawningCheck == false)
        {
            CancelInvoke("Spawn");
        }

        // Call the Spawn function after a delay of the spawnTime and then continue to call after the same amount of time.

        if (PlayerHealthScript.hp <= 0)
        {
            spawningCheck = false;
        }
    }

    void Spawn ()
    {
		float spawnY = Random.Range(-4.2f, 4.2f);
        _enemy = (GameObject)Instantiate(enemyPrefab, new Vector3(10, spawnY, 0), Quaternion.identity);
    }

}
