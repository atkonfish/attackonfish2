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
		
		switch(tier % 8)
		{
			case 1:
			enemyOne.GetComponent<SpriteRenderer>().color = new Color(0.6f, 0.6f, 1, 1);
			enemyTwo.GetComponent<SpriteRenderer>().color = new Color(0.6f, 0.6f, 1, 1);
			bossOne.GetComponent<SpriteRenderer>().color = new Color(0.6f, 0.6f, 1, 1);
			bossTwo.GetComponent<SpriteRenderer>().color = new Color(0.6f, 0.6f, 1, 1);
			break;
			
			case 2:
			enemyOne.GetComponent<SpriteRenderer>().color = new Color(1, 0.6f, 0.6f, 1);
			enemyTwo.GetComponent<SpriteRenderer>().color = new Color(1, 0.6f, 0.6f, 1);
			bossOne.GetComponent<SpriteRenderer>().color = new Color(1, 0.6f, 0.6f, 1);
			bossTwo.GetComponent<SpriteRenderer>().color = new Color(1, 0.6f, 0.6f, 1);
			break;
			
			case 3:
			enemyOne.GetComponent<SpriteRenderer>().color = new Color(0.6f, 1, 0.6f, 1);
			enemyTwo.GetComponent<SpriteRenderer>().color = new Color(0.6f, 1, 0.6f, 1);
			bossOne.GetComponent<SpriteRenderer>().color = new Color(0.6f, 1, 0.6f, 1);
			bossTwo.GetComponent<SpriteRenderer>().color = new Color(0.6f, 1, 0.6f, 1);
			break;
			
			case 4:
			enemyOne.GetComponent<SpriteRenderer>().color = new Color(0.3f, 0.8f, 0.8f, 1);
			enemyTwo.GetComponent<SpriteRenderer>().color = new Color(0.3f, 0.8f, 0.8f, 1);
			bossOne.GetComponent<SpriteRenderer>().color = new Color(0.3f, 0.8f, 0.8f, 1);
			bossTwo.GetComponent<SpriteRenderer>().color = new Color(0.3f, 0.8f, 0.8f, 1);
			break;
			
			case 5:
			enemyOne.GetComponent<SpriteRenderer>().color = new Color(1, 0.3f, 1, 1);
			enemyTwo.GetComponent<SpriteRenderer>().color = new Color(1, 0.3f, 1, 1);
			bossOne.GetComponent<SpriteRenderer>().color = new Color(1, 0.3f, 1, 1);
			bossTwo.GetComponent<SpriteRenderer>().color = new Color(1, 0.3f, 1, 1);
			break;

			case 6:
			enemyOne.GetComponent<SpriteRenderer>().color = new Color(0.8f, 0.7f, 0.1f, 1);
			enemyTwo.GetComponent<SpriteRenderer>().color = new Color(0.8f, 0.7f, 0.1f, 1);
			bossOne.GetComponent<SpriteRenderer>().color = new Color(0.8f, 0.7f, 0.1f, 1);
			bossTwo.GetComponent<SpriteRenderer>().color = new Color(0.8f, 0.7f, 0.1f, 1);
			break;
			
			case 7:
			enemyOne.GetComponent<SpriteRenderer>().color = new Color(0.3f, 0.3f, 0.3f, 1);
			enemyTwo.GetComponent<SpriteRenderer>().color = new Color(0.3f, 0.3f, 0.3f, 1);
			bossOne.GetComponent<SpriteRenderer>().color = new Color(0.3f, 0.3f, 0.3f, 1);
			bossTwo.GetComponent<SpriteRenderer>().color = new Color(0.3f, 0.3f, 0.3f, 1);
			break;

			case 0:
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



















