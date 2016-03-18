using UnityEngine;
using System.Collections;

public class itemSpawn : MonoBehaviour {

	[SerializeField] private GameObject itemPrefab;
	[SerializeField] private GameObject virusPrefab;
	private GameObject _item;
	//Variables for time duration between item spawns
	public float itemBaseInterval = 10.0f;
	int itemChance;
	private float itemInterval;
	//Variables for chances of virus spawning instead of boost item
	int virusSpawnNumber;
	int virusSpawnRate;
	
	void Start() {
		itemChance = Random.Range(1, 4);
		itemInterval = itemBaseInterval * itemChance;
		virusSpawnNumber = Random.Range(0, 10);
		virusSpawnRate = 3; //actual rate is value multiply by 10%
	}
	
	void Update () {
		itemInterval -= Time.deltaTime;
		if (itemInterval <= 0) {
			if (virusSpawnNumber <= virusSpawnRate) {
				_item = Instantiate(virusPrefab) as GameObject;
				float spawnY = Random.Range(-4.2f, 4.2f);
				_item.transform.position = new Vector3(10, spawnY, 0);
				itemChance = Random.Range(1, 4);
				itemInterval = itemBaseInterval * itemChance;
				virusSpawnNumber = Random.Range(0, 10);
			} else {
				_item = Instantiate(itemPrefab) as GameObject;
				float spawnY = Random.Range(-4.2f, 4.2f);
				_item.transform.position = new Vector3(10, spawnY, 0);
				itemChance = Random.Range(1, 4);
				itemInterval = itemBaseInterval * itemChance;
				virusSpawnNumber = Random.Range(0, 10);
			}
		}
		//Force spawn boost item
		if (Input.GetKeyUp(KeyCode.F1)) {
			_item = Instantiate(itemPrefab) as GameObject;
			_item.transform.position = new Vector3(10, 0, 0);
		} 
		//Force spawn virus
		else if (Input.GetKeyUp(KeyCode.F2)) {
			_item = Instantiate(virusPrefab) as GameObject;
			_item.transform.position = new Vector3(10, 0, 0);
		}
	}
}
