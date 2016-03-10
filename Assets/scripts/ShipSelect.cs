using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ShipSelect : MonoBehaviour {
    public GameObject[] units;
    public static int currUnit = 0;
    // Use this for initialization
    void Start() {
        for (int i = 0; i < units.Length; i++)
        {
            units[i].SetActive(false);
        }
        units[currUnit].SetActive(true);
    }    
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            if (currUnit >= 1)
             {
                units[currUnit].SetActive(false);
                currUnit = 0;
                units[currUnit].SetActive(true);
             }
             else
             {
                 units[currUnit].SetActive(false);
                 ++currUnit;
                 units[currUnit].SetActive(true);
             }
            //rightDir(currUnit, units);
        }

        if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
             if (currUnit <= 0)
            {
                units[currUnit].SetActive(false);
                currUnit = 1;
                 units[currUnit].SetActive(true);
             }
             else
             {
                 units[currUnit].SetActive(false);
                 --currUnit;
                 units[currUnit].SetActive(true);
             }
            //leftDir(currUnit, units);
        }
        if (Input.GetKeyUp(KeyCode.Return)) {

            SceneManager.LoadScene("Play");
        }
            
	}
   
    //Doesn't work and don't know why.
    /* void leftDir(int currUnit , GameObject[] units) {

        if (currUnit <= 0)
        {
            units[currUnit].SetActive(false);
            currUnit = 1;
            units[currUnit].SetActive(true);
           
        }
        else
        {
            units[currUnit].SetActive(false);
            --currUnit;
            units[currUnit].SetActive(true);
            
        }
    }
    
    void rightDir(int currUnit, GameObject[] units){

        if (currUnit >= 1)
        {
            units[currUnit].SetActive(false);
            currUnit = 0;
            units[currUnit].SetActive(true);
        }
        else
        {
            units[currUnit].SetActive(false);
            ++currUnit;
            units[currUnit].SetActive(true);
        }
    }*/
}
