using UnityEngine;
using System.Collections;

public class ColourManager : MonoBehaviour
{
	[SerializeField] private GameObject enemyOne;
	[SerializeField] private GameObject enemyTwo;
	[SerializeField] private GameObject bossOne;
	[SerializeField] private GameObject bossTwo;
	
	private int tier = 0;
	
	void Awake()
	{
		enemyOne.GetComponent<SpriteRenderer>().color = Color.white;
		enemyTwo.GetComponent<SpriteRenderer>().color = Color.white;
		bossOne.GetComponent<SpriteRenderer>().color = Color.white;
		bossTwo.GetComponent<SpriteRenderer>().color = Color.white;
	}
		
	
	public void cycleColours()
	{
		tier++;
		
		switch(tier)
		{
			case 1:
			enemyOne.GetComponent<SpriteRenderer>().color = Color.blue;
			enemyTwo.GetComponent<SpriteRenderer>().color = Color.blue;
			bossOne.GetComponent<SpriteRenderer>().color = Color.blue;
			bossTwo.GetComponent<SpriteRenderer>().color = Color.blue;
			break;
			
			case 2:
			enemyOne.GetComponent<SpriteRenderer>().color = Color.red;
			enemyTwo.GetComponent<SpriteRenderer>().color = Color.red;
			bossOne.GetComponent<SpriteRenderer>().color = Color.red;
			bossTwo.GetComponent<SpriteRenderer>().color = Color.red;
			break;
			
			case 3:
			enemyOne.GetComponent<SpriteRenderer>().color = Color.green;
			enemyTwo.GetComponent<SpriteRenderer>().color = Color.green;
			bossOne.GetComponent<SpriteRenderer>().color = Color.green;
			bossTwo.GetComponent<SpriteRenderer>().color = Color.green;
			break;
			
			case 4:
			enemyOne.GetComponent<SpriteRenderer>().color = Color.black;
			enemyTwo.GetComponent<SpriteRenderer>().color = Color.black;
			bossOne.GetComponent<SpriteRenderer>().color = Color.black;
			bossTwo.GetComponent<SpriteRenderer>().color = Color.black;
			break;
			
			case 5:
			enemyOne.GetComponent<SpriteRenderer>().color = Color.cyan;
			enemyTwo.GetComponent<SpriteRenderer>().color = Color.cyan;
			bossOne.GetComponent<SpriteRenderer>().color = Color.cyan;
			bossTwo.GetComponent<SpriteRenderer>().color = Color.cyan;
			break;
			
			case 6:
			enemyOne.GetComponent<SpriteRenderer>().color = Color.gray;
			enemyTwo.GetComponent<SpriteRenderer>().color = Color.gray;
			bossOne.GetComponent<SpriteRenderer>().color = Color.gray;
			bossTwo.GetComponent<SpriteRenderer>().color = Color.gray;
			break;
			
			case 7:
			enemyOne.GetComponent<SpriteRenderer>().color = Color.magenta;
			enemyTwo.GetComponent<SpriteRenderer>().color = Color.magenta;
			bossOne.GetComponent<SpriteRenderer>().color = Color.magenta;
			bossTwo.GetComponent<SpriteRenderer>().color = Color.magenta;
			break;
			
			case 8:
			enemyOne.GetComponent<SpriteRenderer>().color = Color.yellow;
			enemyTwo.GetComponent<SpriteRenderer>().color = Color.yellow;
			bossOne.GetComponent<SpriteRenderer>().color = Color.yellow;
			bossTwo.GetComponent<SpriteRenderer>().color = Color.yellow;
			break;
			
			case 9:
			enemyOne.GetComponent<SpriteRenderer>().color = Color.red;
			enemyTwo.GetComponent<SpriteRenderer>().color = Color.red;
			bossOne.GetComponent<SpriteRenderer>().color = Color.red;
			bossTwo.GetComponent<SpriteRenderer>().color = Color.red;
			break;
			
			case 10:
			enemyOne.GetComponent<SpriteRenderer>().color = Color.white;
			enemyTwo.GetComponent<SpriteRenderer>().color = Color.white;
			bossOne.GetComponent<SpriteRenderer>().color = Color.white;
			bossTwo.GetComponent<SpriteRenderer>().color = Color.white;
			break;
			
			default:
			break;
		}
	}
}



















