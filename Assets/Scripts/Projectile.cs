using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {

	private float damage = 100f;
	private Projectile missile;
		
	public float GetDamage()
	{
		return damage;
	}
	
	public void DestroyProjectile()
	{
		print("missile destroyed!!");
		Destroy(this.gameObject);
	}

	void OnCollisionEnter2D(Collision2D coll)
	{
		missile = coll.gameObject.GetComponent<Projectile>();
		if(missile)
		{
			DataStorage.Score += 5;
			missile.DestroyProjectile();
		
		}
		
	}
}
