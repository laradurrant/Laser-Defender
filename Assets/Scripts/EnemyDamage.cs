using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour {

	public float projectileSpeed;
	public float pFire = 1f;
	private float chance = 0f;
	
	public float enemyHealth;
	
	public GameObject projectile;
	private Projectile missile;

	void Start()
	{
		enemyHealth = 200f;

	

	}

	void FixedUpdate()
	{
		
		
		FireAtPlayer();
				
	}
	
	void FireAtPlayer()
	{
	

		chance = Random.Range(0f, 150f);
		
		if(chance < pFire)
		{
			Vector3 nudge = transform.position + new Vector3(0,-0.5f,0);
			
			GameObject beam = Instantiate(projectile, nudge, Quaternion.identity) as GameObject;
			beam.GetComponent<Rigidbody2D>().velocity = new Vector3(0,-projectileSpeed, 0);
		//	beam.GetComponent<Rigidbody2D>().rotation = transform.rotation;
			Physics2D.IgnoreCollision(beam.GetComponent<Collider2D>(), GetComponent<Collider2D>());
			
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
				DataStorage.Score += 20;
				Destroy(this.gameObject);
		}
		
	
		
	}
	
	
}
