using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	private Vector3 playerPosition;
	private Rigidbody2D rb;
	public float speed = 0.1f;
	public GameObject projectile;
	public float projectileSpeed = -1f;
	public float firingRate = 0.2f;
	private Projectile missile;

	
	public AudioSource laserFX;
	public AudioClip deadPlayerFX;
	public AudioClip damagedPlayerFX;
//	public float playerHealth;
	public ParticleSystem explosion;
	private bool isDead = false;
	private float currentTime = 0;
	private float waitTime = 0;
	
	
	// Use this for initialization
	void Start () {
		//playerPosition = this.transform.position; 
		isDead = false;
		currentTime = 0;
		
	}
	
	void Fire()
	{
		laserFX.Play();
		GameObject beam = Instantiate(projectile, transform.position, Quaternion.identity) as GameObject;
		beam.GetComponent<Rigidbody2D>().velocity = new Vector3(0,projectileSpeed, 0);
        Physics2D.IgnoreCollision(beam.GetComponent<Collider2D>(), GetComponent<Collider2D>());
	}
	
	void Update()
	{
		currentTime = Time.time;
		
	
		
		if(isDead && currentTime > waitTime)
		{
			
			
		  
			LevelManager levelmanager = GameObject.FindObjectOfType<LevelManager>();
			levelmanager.LoadLevel ("Lose Screen");
			
			isDead = false;
			DataStorage.Health = 500f;
		
			
		}
		
		if(!isDead)
		{
			if(Input.GetKeyDown(KeyCode.Space))
			{
				InvokeRepeating("Fire", 0.000001f, firingRate);
				
			}
			if(Input.GetKeyUp(KeyCode.Space))
			{
				CancelInvoke("Fire");
			}
		}
		
	}
	
	void OnCollisionEnter2D(Collision2D coll)
	{
	
		
		missile = coll.gameObject.GetComponent<Projectile>();
		
		if(missile)
		{
			AudioSource.PlayClipAtPoint(damagedPlayerFX, this.transform.position);
			print("player hit by missile");
			missile.DestroyProjectile();
		    TakeDamage();
		}
	}
	
	
	void TakeDamage()
	{
		
		
		DataStorage.Health -= missile.GetDamage();
		if(DataStorage.Health <= 0)
		{
				YouLose();
				isDead = true;
				
				
		}
		
	
		
	}
	
	void YouLose()
	{
			
			AudioSource.PlayClipAtPoint(deadPlayerFX, this.transform.position);
		
			explosion.Play();
			
			currentTime = Time.time;
			waitTime = currentTime + 1f;
		
			
	
			
	}
	

	
	// Update is called once per frame
	void FixedUpdate () {
		
		
		//print(playerPosition);
		
		if(!isDead)
		{
			if (Input.GetKey(KeyCode.LeftArrow))
			{
				//print("Left button is held down");
				playerPosition = this.transform.position + (Vector3.left * speed * Time.deltaTime);
				transform.position = new Vector3(Mathf.Clamp(playerPosition.x, -6F, 6.0F), -3f, 0);
				
			}
			
			if (Input.GetKey(KeyCode.RightArrow))
			{
				//print("Right button is held down");
				playerPosition = this.transform.position + (Vector3.right * speed * Time.deltaTime);
				transform.position = new Vector3(Mathf.Clamp(playerPosition.x, -6F, 6.0F), -3f, 0);
			}
		}
	}
	
	
	
}
