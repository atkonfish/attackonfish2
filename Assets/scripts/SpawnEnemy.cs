using UnityEngine;
using System.Collections;

public class SpawnEnemy : MonoBehaviour {
   
	[SerializeField] public GameObject enemy1Prefab;
	[SerializeField] public GameObject enemy2Prefab;
	[SerializeField] public GameObject boss1Prefab;
	[SerializeField] public GameObject boss2Prefab;
	private GameObject _enemy;
    public float spawnTime = 3f;
    public static bool spawningCheck = false;
	//Number of bossesKilled
	private int bossKilled = 0;
	//Currently fighting a boss
	private bool bossFight = false;
	//Flag to determine which boss to spawn
	private bool spawnBossOne = true;
	//Spawn a boss everytime score increases by SCORE_INTERVAL
	const int SCORE_INTERVAL = 500;
	
	void Start () {
		spawningCheck = false;
		// Call the Spawn function after a delay of the spawnTime and then continue to call after the same amount of time.
		InvokeRepeating("Spawn", spawnTime, spawnTime);
		
	} 
	
    void Update()
    {
		//Force spawn boss
		if (Input.GetKeyDown(KeyCode.F11)) {
			CancelInvoke("Spawn");
			GameObject.Instantiate(boss1Prefab, new Vector3(13, 0, 0), Quaternion.identity);
		} else if (Input.GetKeyDown(KeyCode.F12)) {
			CancelInvoke("Spawn");
			GameObject.Instantiate(boss2Prefab, new Vector3(13, 0, 0), Quaternion.identity);
		}
		
		//Spawn a boss everytime score increases by SCORE_INTERVAL
		if (scoreCounter.score != 0 && !bossFight) {
			if ((scoreCounter.score - bossKilled * 2000) % (SCORE_INTERVAL + bossKilled * SCORE_INTERVAL) == 0) {
				if (spawnBossOne) {
					CancelInvoke("Spawn");
					GameObject.Instantiate(boss1Prefab, new Vector3(13, 0, 0), Quaternion.identity);
					spawnBossOne = false;
					bossFight = true;
				} else {
					CancelInvoke("Spawn");
					GameObject.Instantiate(boss2Prefab, new Vector3(13, 0, 0), Quaternion.identity);
					spawnBossOne = true;
					bossFight = true;
				}
			}
		}
		
		// Re-starting enemy spawn
		if (spawningCheck) {
			spawningCheck = false;
			bossKilled++;
			if (bossKilled % 2 == 0)
				bad1hit.attackPower++;
			itemSpawn.hpSpawn = true;
			bossFight = false;
			InvokeRepeating("Spawn", spawnTime, spawnTime);
		}
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
