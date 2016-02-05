using UnityEngine;
using System.Collections;

public class itemSpawn : MonoBehaviour {

	[SerializeField] private GameObject itemPrefab;
	private GameObject _item;
	public float itemBaseInterval = 10.0f;
	int itemChance;
	private float itemInterval;
	
	void Start() {
		itemChance = Random.Range(1, 4);
		itemInterval = itemBaseInterval * itemChance;
	}
	
	void Update () {
		itemInterval -= Time.deltaTime;
		if (itemInterval <= 0) {
			_item = Instantiate(itemPrefab) as GameObject;
			float spawnY = Random.Range(-4.2f, 4.2f);
			_item.transform.position = new Vector3(10, spawnY, 0);
			itemChance = Random.Range(1, 4);
			itemInterval = itemBaseInterval * itemChance;
		}
	}
}
