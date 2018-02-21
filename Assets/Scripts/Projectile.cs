using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {

	private float damage = 100f;
	private Projectile missile;
	public ParticleSystem explosion;
		
	public float GetDamage()
	{
		return damage;
	}
	
	public void DestroyProjectile()
	{
		print("missile destroyed!!");
		explosion.Play();

		Destroy(this.gameObject, 0.1f);
	}

	void OnCollisionEnter2D(Collision2D coll)
	{
		missile = coll.gameObject.GetComponent<Projectile>();
		if(missile)
		{
			DataStorage.Score += 10;
			missile.DestroyProjectile();
		
		}
		
		
		
		
	}
}
