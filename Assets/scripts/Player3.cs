using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player3 : PlayerStats {
	
	/*
	Submarine 3, attack ship, weak attack and weak defence, needs the boost from items and viruses (positive effect)
	Ability effect(in shoot()), fire a burst shot of 3 bullets instead of 1
	Virus effect (in shoot()), fire a strong bullet with longer cool down time
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
	public GameObject bullet2;
    //Defines a delay for bullets being shot
    const float DELAY_SHOT = 0.1f;
	const float VIRUS_DELAY_SHOT = 0.8f;
    //Defines the cool down time for the delay
    float coolDown = 0;
	//Item boost
    float boostDuration;
	const float BOOST_TIME = 15.0f;
	//Virus
    float virusDuration;
	const float VIRUS_TIME = 15.0f;
	//Max HP
	const int HP_MAX = 70;
	//Audio
	public AudioSource shooting;
	public AudioSource death;
	public AudioSource burst;
	public AudioSource takeDamage;
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
		hp = HP_MAX;
		
		//Set player speed
		speed = 7.0f;

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
		//Check player hp
		if (hp <= 0)
		{
			hp = 0;
			GetComponent<PolygonCollider2D>().enabled = false;
			playerAnimation.SetBool ("alive", false);
		} else {
			hp = (hp > HP_MAX) ? HP_MAX : hp;
			movement ();
			shoot ();
			if (virusBoost) {
				virusDuration -= Time.deltaTime;
				if (virusDuration <= 0)
				{
					virusBoost = false;
					virusDuration = VIRUS_TIME;
				}
			}
			if (itemBoost)
			{
				boostDuration -= Time.deltaTime;
				if (boostDuration <= 0)
				{
					itemBoost = false;
					boostDuration = BOOST_TIME;
				}
			}
		}
	}

	private IEnumerator waitLoad (){
		death.Play ();
		yield return new WaitForSeconds (4f);
		Destroy (gameObject);
		SceneManager.LoadScene ("High Scores");
	}
	
	void OnTriggerEnter2D(Collider2D coll)
    {

        if (coll.gameObject.tag == "enemyBullet")
        { 
			if (hp > 0) {
				takeDamage.Play();
				StartCoroutine (Flash ());
				hp -= bad1hit.attackPower;
			}
		}

        if (coll.gameObject.tag == "enemy")
        { 
			if (hp > 0) {
				takeDamage.Play();
				StartCoroutine (Flash ());
				hp -= bad1hit.attackPower * 4; 
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
		if (Input.GetKey(KeyCode.A) && coolDown <= 0 && !itemBoost && !virusBoost)
        {
            coolDown = DELAY_SHOT;
            //Creates a bullet from the position of the gun barrel.
            Instantiate(bullet, barrel.transform.position, Quaternion.identity);
			shooting.Play ();
        }
		//Ship ability 3 burst shot
        if (Input.GetKey(KeyCode.A) && coolDown <= 0 && itemBoost && !virusBoost)
        {
            coolDown = DELAY_SHOT;
            Instantiate(bullet, barrel.transform.position, Quaternion.Euler(0, 0, 0));
            Instantiate(bullet, barrel.transform.position, Quaternion.Euler(0, 0, 10));
            Instantiate(bullet, barrel.transform.position, Quaternion.Euler(0, 0, -10));
			burst.Play ();
        }
		//One strong bullet from virus
		if (Input.GetKey(KeyCode.A) && coolDown <= 0 && !itemBoost && virusBoost)
        {
            coolDown = VIRUS_DELAY_SHOT;
            Instantiate(bullet, barrel.transform.position, Quaternion.identity);

			shooting.Play ();
        }
		//Hidden ability with both item and virus boost active
		if (Input.GetKey(KeyCode.A) && coolDown <= 0 && itemBoost && virusBoost)
        {
            coolDown = VIRUS_DELAY_SHOT;
            Instantiate(bullet, barrel.transform.position, Quaternion.Euler(0, 0, 0));
            Instantiate(bullet, barrel.transform.position, Quaternion.Euler(0, 0, 10));
            Instantiate(bullet, barrel.transform.position, Quaternion.Euler(0, 0, -10));
			burst.Play ();
        }

    }
	private IEnumerator resetAnimation (){
		yield return new WaitForSeconds (0.01f);
		playerAnimation.SetBool ("shoot", false);
	}
}

