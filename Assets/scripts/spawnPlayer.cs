using UnityEngine;
using System.Collections;

public class spawnPlayer : MonoBehaviour {

	public static int spawnNum;
	[SerializeField] private GameObject unit1prefab;
	[SerializeField] private GameObject unit2prefab;
	[SerializeField] private GameObject unit3prefab;

	// Use this for initialization
	void Start () {
		if (spawnNum == 1)
			Instantiate (unit1prefab);
		else if (spawnNum == 2)
			Instantiate (unit2prefab);
		else if (spawnNum == 3)
			Instantiate (unit3prefab);
	}
}
