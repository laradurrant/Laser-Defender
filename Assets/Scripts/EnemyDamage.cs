using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour {

	public float projectileSpeed;
	public float firingRate;
	public float enemyHealth;
	
	public GameObject projectile;
	private Projectile missile;

	void Start()
	{
		enemyHealth = 100f;
		firingRate = 20f;
	
		//FireAtPlayer();
	}

	
	void FireAtPlayer()
	{
		GameObject beam = Instantiate(projectile, transform.position, Quaternion.identity) as GameObject;
		beam.GetComponent<Rigidbody2D>().velocity = new Vector3(0,-projectileSpeed, 0);
	    Physics2D.IgnoreCollision(beam.GetComponent<Collider2D>(), GetComponent<Collider2D>());
		
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
				
				Destroy(this.gameObject);
		}
		
	
		
	}
	
	
}
