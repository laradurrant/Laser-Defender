using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour {

	public float projectileSpeed;
	public float itemSpeed;
	
	public float pFire = 1f;
	private float chance = 0f;
	
	public float enemyHealth;
	
	public GameObject projectile;
	private Projectile missile;
	
	
	public GameObject potion;
	private HealthPotion health;
	
	
	public AudioClip deadEnemyFX;
	public AudioClip shootPlayerFX;
	
	public ParticleSystem explosion;

	private float currentTime;
	private float delayTime;
	public float recharge;
	
	private Vector3 nudge;

	public float dropRate = 20;
	private float diceRoll;
	
	public int score;
	
	void Start()
	{
	
		
	

	}

	void FixedUpdate()
	{
		
	
		if(Time.time > delayTime)
		{

			FireAtPlayer();
			
		}

		
	}
	
	void FireAtPlayer()
	{
	

		chance = Random.Range(0f, 150f);
		
		if(chance < pFire)
		{
	
			
			AudioSource.PlayClipAtPoint(shootPlayerFX, this.transform.position);

			nudge = transform.position + new Vector3(0,-0.5f,0);		
			GameObject beam = Instantiate(projectile, nudge, Quaternion.identity) as GameObject;
			beam.GetComponent<Rigidbody2D>().velocity = new Vector3(0,-projectileSpeed, 0);
			

			Physics2D.IgnoreCollision(beam.GetComponent<Collider2D>(), GetComponent<Collider2D>());
			delayTime = Time.time + recharge;
		
		}
		
		
		
		
	}
	

	void OnCollisionEnter2D(Collision2D coll)
    {
	

		missile = coll.gameObject.GetComponent<Projectile>();
		
		

		
		if(missile)
		{
			
			//Debug.Log("hit by missile");
			missile.DestroyProjectile();
		    TakeDamage();
		}
		
	}
	
	void TakeDamage()
	{

		enemyHealth -= missile.GetDamage();
		if(enemyHealth <= 0)
		{
				diceRoll = Random.Range(0,100);
				if(diceRoll < dropRate)
				{
					DropHealth();
				}
				
				AudioSource.PlayClipAtPoint(deadEnemyFX, this.transform.position);
				DataStorage.Score += score;
				explosion.Play();
				

				Destroy(this.gameObject,0.3f);
				
		}
		
	
		
	}
	
	void DropHealth()
	{
		nudge = transform.position + new Vector3(0,-0.5f,0);
		GameObject health = Instantiate(potion, nudge, Quaternion.identity) as GameObject;
		
		health.GetComponent<Rigidbody2D>().velocity = new Vector3(0,-itemSpeed, 0);
		
		
	}
	
}
