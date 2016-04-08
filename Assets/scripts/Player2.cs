using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player2 : PlayerStats {

	/*
	Submarine 2, tank ship, slower attack but uses high hp to crush enemies, normally fire 2 bullets at once
	Ability effect(in OnTriggerEnter2D(Collider2D coll)), neglect damage from enemy bullets and recover hp for every enemy crushed
	Virus effect (in OnTriggerEnter2D(Collider2D coll)), weaken defense all damages are tripled
	*/
	
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
    const float DELAY_SHOT = 0.4f;
    //Defines the cool down time for the delay
    float coolDown = 0;
	//Item boost
    float boostDuration;
	const float BOOST_TIME = 10.0f;
	//Virus
    float virusDuration;
	const float VIRUS_TIME = 5.0f;
	//Audio
	public AudioSource shooting;
	public AudioSource death;

	//Animation
	[SerializeField] private GameObject bubbleObj;
	public GameObject bubbleSpawningPoint;
	private Animator playerAnimation;
	private bool bubbleCondition = true;
	
	void Start () {
		
		//Border for the submarine. used for movement restriction
		screenRatio = (float)Screen.width / (float)Screen.height;
		widthOrtho = Camera.main.orthographicSize * screenRatio;
		subBoundaryRadius = 1f;
		
		//Initalize hp
		hp = 150;
		
		//Set player speed
		speed = 3.0f;
		
		//Initalize ability cool down time
		boostDuration = BOOST_TIME;
		itemBoost = false;
		
		//Initalize virus cool down time
		virusDuration = VIRUS_TIME;
		virusBoost = false;
		
		//Screen flash when player is hit
		hit = GameObject.FindWithTag ("flash");
		hit.GetComponentInChildren<RawImage>().enabled = false;

		//Get Animator
		playerAnimation = GetComponent<Animator>();
	}
	
	void Update () {
		//Check player hp
		if (hp <= 0)
		{
			death.Play ();
			StartCoroutine (waitLoad ());
		}

		if (virusBoost) {
			virusDuration -= Time.deltaTime;
            if (virusDuration <= 0)
            {
                virusBoost = false;
                virusDuration = 5.0f;
            }
		}
		if (itemBoost)
        {
            boostDuration -= Time.deltaTime;
            if (boostDuration <= 0)
            {
                itemBoost = false;
                boostDuration = 10.0f;
            }
        }
		if (hp > 0) {
			movement ();
		}
		shoot ();
	}

	private IEnumerator waitLoad (){
		yield return new WaitForSeconds (4f);
		Destroy (gameObject);
		SceneManager.LoadScene ("High Scores");
	}

	void OnTriggerEnter2D(Collider2D coll)
    {
		if (virusBoost) {
			if (coll.gameObject.tag == "enemyBullet")
			{ 
				StartCoroutine (Flash ());
				hp -= bad1hit.attackPower * 3;
			}

			if (coll.gameObject.tag == "enemy")
			{ 
				StartCoroutine (Flash ());
				hp -= 6; 
			}
		} else if (itemBoost) {
			if (coll.gameObject.tag == "enemyBullet")
			{ 

			}

			if (coll.gameObject.tag == "enemy")
			{ 
				if (hp + 1 <= 150)
					hp += 1; 
			}
		} else {
			if (coll.gameObject.tag == "enemyBullet")
			{ 
				StartCoroutine (Flash ());
				hp -= bad1hit.attackPower;
			}

			if (coll.gameObject.tag == "enemy")
			{ 
				StartCoroutine (Flash ());
				hp -= 2; 
			}
		}
    }
	
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


		if (Input.GetAxisRaw ("Horizontal") > 0 && bubbleCondition) {
			bubbleCondition = false;
			GameObject bubbles = Instantiate (bubbleObj) as GameObject;
			bubbles.transform.position = bubbleSpawningPoint.transform.position;
			StartCoroutine (changeBubbleCondition ());
		}
	}

	private IEnumerator changeBubbleCondition (){
		yield return new WaitForSeconds (0.1f);
		bubbleCondition = true;
	}

	void shoot()
    {
        coolDown -= Time.deltaTime;

		if (Input.GetKey (KeyCode.A) && coolDown <= 0) {
			playerAnimation.SetBool ("shoot", true);
			StartCoroutine (resetAnimation ());
		}

        //single shot
		if (Input.GetKey(KeyCode.A) && coolDown <= 0)
        {
            coolDown = DELAY_SHOT;
            //Normally shoot 2 bullet of the gun barrel.
            Instantiate(bullet, barrel.transform.position, Quaternion.Euler(0, 0, 10));
            Instantiate(bullet, barrel.transform.position, Quaternion.Euler(0, 0, -10));
			shooting.Play ();
        }
    }
	private IEnumerator resetAnimation (){
		yield return new WaitForSeconds (0.01f);
		playerAnimation.SetBool ("shoot", false);
	}
}
