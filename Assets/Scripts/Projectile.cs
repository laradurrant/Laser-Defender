﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {

	private float damage = 100f;
	
	public float GetDamage()
	{
		return damage;
	}
	
	public void DestroyProjectile()
	{
		print("missile destroyed!!");
		Destroy(this.gameObject);
	}

}
