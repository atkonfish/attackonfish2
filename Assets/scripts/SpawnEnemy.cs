using UnityEngine;
using System.Collections;

public class SpawnEnemy : MonoBehaviour {
   
	[SerializeField] public GameObject enemy1Prefab;
	[SerializeField] public GameObject enemy2Prefab;
	[SerializeField] public GameObject bossPrefab;
	private GameObject _enemy;
    public float spawnTime = 3f;
    bool spawningCheck = true;


    void Start()
    {

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
		if (Input.GetKeyUp(KeyCode.F1)) {
			spawningCheck = false;
			GameObject.Instantiate(bossPrefab, new Vector3(13, 0, 0), Quaternion.identity);
		}
		
        if (spawningCheck == false)
        {
            CancelInvoke("Spawn");
        }

        // Call the Spawn function after a delay of the spawnTime and then continue to call after the same amount of time.
    }

    void Spawn ()
    {
		float spawnY = Random.Range(-4.2f, 4.2f);
		int enemyType = Random.Range(0, 2);
		if (enemyType == 0)
			_enemy = (GameObject)Instantiate(enemy1Prefab, new Vector3(10, spawnY, 0), Quaternion.identity);
		else if (enemyType == 1)
			_enemy = (GameObject)Instantiate(enemy2Prefab, new Vector3(10, spawnY, 0), Quaternion.identity);
    }

}
