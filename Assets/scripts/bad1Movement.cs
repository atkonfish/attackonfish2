using UnityEngine;
using System.Collections;

public class bad1Movement : MonoBehaviour {

	public float speed = 5f;
    public float speed2 = 2.5f;

    private float x;
    private float y;

    private float UpOrDown;
    public float decisionPeriod;

    bool InBoundsUp = false;
    bool InBoundsDown = false;


    void Move()

    {
        decisionPeriod = Time.time + 1.5f;

    }

    // Update is called once per frame
    void Update() {
 
        x = -speed * Time.deltaTime;
        y = (-speed / 2) * Time.deltaTime;

			

		if (decisionPeriod < Time.time)
		{
			UpOrDown = Random.value;
			decisionPeriod = Time.time + 1.5f;
			
			if (UpOrDown > 0.5f)
			{
				InBoundsUp = false;
				InBoundsDown = true;
			}
			else
			{
				InBoundsDown = false;
				InBoundsUp = true;
			}	
		}
		
		
		if (InBoundsDown == true)
        {
            gameObject.transform.Translate(x, y, 0);
        }
        else
        {
            gameObject.transform.Translate(x, -y, 0);
        }
      

        if (gameObject.transform.position.y <= -4.2f)
        {
            decisionPeriod = 0;
            InBoundsDown = false;
            InBoundsUp = true;
           
        }

		
        if (gameObject.transform.position.y >= 4.2f)
        {
            decisionPeriod = 0;
            InBoundsUp = false;
            InBoundsDown = true;
        }
    

            if (this.transform.position.x < -11)
        {
            Destroy(gameObject);
        }
	}
}