﻿using UnityEngine;
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
	private bool bubbleCondition = true;
	//Defines the bubble animation prefab
	[SerializeField] private GameObject bubbleObj;
	//Defines the bubble spawning point
	public GameObject bubbleSpawningPoint;
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
	//Audio
	public AudioSource shooting;
	public AudioSource death;
	public AudioSource burst;
	//Animation
	private Animator playerAnimation;
	
	void Start () {
		//Border for the submarine. used for movement restriction
		screenRatio = (float)Screen.width / (float)Screen.height;
		widthOrtho = Camera.main.orthographicSize * screenRatio;
		subBoundaryRadius = 1f;
		
		//Initalize hp
		hp = 70;
		
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
                virusDuration = VIRUS_TIME;
            }
		}
		if (hp > 0) {
			movement ();
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
		shoot ();
	}

	private IEnumerator waitLoad (){
		yield return new WaitForSeconds (4f);
		SceneManager.LoadScene ("High Scores");
	}

	void OnTriggerEnter2D(Collider2D coll)
    {

        if (coll.gameObject.tag == "enemyBullet")
        { 
			StartCoroutine (Flash ());
			hp -= 1;
		}

        if (coll.gameObject.tag == "enemy")
        { 
			StartCoroutine (Flash ());
			hp -= 4; 
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

		//Animation
		/* Show bubbles behind submarine when the it move forward.*/
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

		//Animation
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
            Instantiate(bullet2, barrel.transform.position, Quaternion.identity);
			shooting.Play ();
        }
		//Hidden ability with both item and virus boost active
		if (Input.GetKey(KeyCode.A) && coolDown <= 0 && itemBoost && virusBoost)
        {
            coolDown = VIRUS_DELAY_SHOT;
            Instantiate(bullet2, barrel.transform.position, Quaternion.Euler(0, 0, 0));
            Instantiate(bullet2, barrel.transform.position, Quaternion.Euler(0, 0, 10));
            Instantiate(bullet2, barrel.transform.position, Quaternion.Euler(0, 0, -10));
			burst.Play ();
        }
    }
	private IEnumerator resetAnimation (){
		yield return new WaitForSeconds (0.01f);
		playerAnimation.SetBool ("shoot", false);
	}
}

