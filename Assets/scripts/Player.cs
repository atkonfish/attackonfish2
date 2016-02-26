using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour {
	
	//Health
	public static int hp;
	//Movement
	private float speed;  //Default speed for player.
    private float subBoundaryRadius;   //Border for the submarine. used for movement restriction
	private float screenRatio;
    private float widthOrtho;
	//Defines the location of the gun barrel. This is where the bullet comes out.
    public GameObject barrel;
    //Defines the bullet for prefab
    public GameObject bullet;
    //Defines a delay for bullets being shot
    float delayshot;
    //Defines the cool down time for the delay
    float coolDown = 0;
	//Item boost
    public static bool itemBoost = false;
    float boostDuration;
	//Virus
	public static bool virusBoost = false;
    float virusDuration;
	
	void Start () {
		
		//Border for the submarine. used for movement restriction
		screenRatio = (float)Screen.width / (float)Screen.height;
		widthOrtho = Camera.main.orthographicSize * screenRatio;
		subBoundaryRadius = 1f;
		
		//Initalize hp
		hp = 100;
		
		//Set player speed
		speed = 5.0f;
		
		//Set time between firing shoots
		delayshot = 0.25f;
		
		//Initalize ability cool down time
		boostDuration = 5.0f;
		itemBoost = false;
		
		//Initalize virus cool down time
		virusDuration = 10.0f;
		virusBoost = false;

	}
	
	void Update () {
		//Check player hp
		if (hp <= 0)
        {
			Destroy (gameObject);
			SceneManager.LoadScene ("High Scores");
        }
		if (virusBoost) {
			movementVirus ();
			virusDuration -= Time.deltaTime;
            if (virusDuration <= 0)
            {
                virusBoost = false;
                virusDuration = 5.0f;
            }
		}
		else
			movement ();
		shoot ();
	}
	
	void OnTriggerEnter2D(Collider2D coll)
    {

        if (coll.gameObject.tag == "enemyBullet")
        { 
			hp--;
		}

        if (coll.gameObject.tag == "enemy")
        { 
			hp -= 4; 
		}
    }
	
	//Reguler movement
	void movement () {
		Vector3 pos = transform.position;
        /*PLAYER MOVEMENT    
            GetAxisRaw inputs can be changed in Edit > Project Settings > Input. Disabled alternative keys for simplicity. 
            May have alternative buttons later on.
        */
        pos.y += Input.GetAxisRaw("Vertical") * speed * Time.deltaTime;
        pos.x += Input.GetAxisRaw("Horizontal") * speed * Time.deltaTime;
       
        /*RESTRICT MOVEMENT WITHIN MAIN CAMERA
            Checks submarine position + the border of it to see if its near the edges of the main camera.
            OrthographicSize takes vertical positions only therefore widthOrtho is made to define the horizontal position of the camera.
            Vertical position may change due to implementation of UI.
        */
        if(pos.y + subBoundaryRadius > Camera.main.orthographicSize){
            pos.y = Camera.main.orthographicSize - subBoundaryRadius;
        }
        if(pos.y - subBoundaryRadius < -Camera.main.orthographicSize){
            pos.y = -Camera.main.orthographicSize + subBoundaryRadius;
        }   
        if(pos.x + subBoundaryRadius > widthOrtho){
            pos.x = widthOrtho - subBoundaryRadius;
        }
        if (pos.x - subBoundaryRadius < -widthOrtho){
            pos.x = -widthOrtho + subBoundaryRadius;
        }
        //Updates player position.
        transform.position = pos;
	}
	
	
	//Changed key movement direction
	void movementVirus () {
		Vector3 pos = transform.position;
        /*PLAYER MOVEMENT    
            GetAxisRaw inputs can be changed in Edit > Project Settings > Input. Disabled alternative keys for simplicity. 
            May have alternative buttons later on.
        */
        pos.y += Input.GetAxisRaw("Horizontal") * speed * 1.5f * Time.deltaTime;
        pos.x += Input.GetAxisRaw("Vertical") * speed * 1.5f * Time.deltaTime;
       
        /*RESTRICT MOVEMENT WITHIN MAIN CAMERA
            Checks submarine position + the border of it to see if its near the edges of the main camera.
            OrthographicSize takes vertical positions only therefore widthOrtho is made to define the horizontal position of the camera.
            Vertical position may change due to implementation of UI.
        */
        if(pos.y + subBoundaryRadius > Camera.main.orthographicSize){
            pos.y = Camera.main.orthographicSize - subBoundaryRadius;
        }
        if(pos.y - subBoundaryRadius < -Camera.main.orthographicSize){
            pos.y = -Camera.main.orthographicSize + subBoundaryRadius;
        }   
        if(pos.x + subBoundaryRadius > widthOrtho){
            pos.x = widthOrtho - subBoundaryRadius;
        }
        if (pos.x - subBoundaryRadius < -widthOrtho){
            pos.x = -widthOrtho + subBoundaryRadius;
        }
        //Updates player position.
        transform.position = pos;
	}
	
	void shoot()
    {
        coolDown -= Time.deltaTime;
        //single shot
		if (Input.GetKey(KeyCode.A) && coolDown <= 0 && !itemBoost)
        {
            coolDown = delayshot;
            //Creates a bullet from the position of the gun barrel.
            Instantiate(bullet, barrel.transform.position, Quaternion.identity);
			GetComponent<AudioSource> ().Play ();
        }
		//Ship ability 3 burst shot
        if (Input.GetKey(KeyCode.A) && coolDown <= 0 && itemBoost)
        {
            coolDown = delayshot;
            Instantiate(bullet, barrel.transform.position, Quaternion.Euler(0, 0, 0));
            Instantiate(bullet, barrel.transform.position, Quaternion.Euler(0, 0, 10));
            Instantiate(bullet, barrel.transform.position, Quaternion.Euler(0, 0, -10));
			GetComponent<AudioSource> ().Play ();
        }

		//Shooting Sound
		/*if (Input.GetKeyDown ("a")) {
			keydown = true;
			if (keydown = true) {
				
				if (Input.GetKeyUp ("a")) {
					GetComponent<AudioSource> ().Stop ();
				}
			}
		}*/

        if (itemBoost)
        {
            boostDuration -= Time.deltaTime;
            if (boostDuration <= 0)
            {
                itemBoost = false;
                boostDuration = 5.0f;
            }
        }
    }
}
