using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPotion : MonoBehaviour {

	PlayerController player;
	Projectile missile;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
		
		
	}
	
	
	void OnCollisionEnter2D(Collision2D coll)
    {
	
		//print("collided with something");
		player = coll.gameObject.GetComponent<PlayerController>();


		missile = coll.gameObject.GetComponent<Projectile>();
		
		if(missile)
		{
			Debug.Log("collided with missile");
			
			Physics2D.IgnoreCollision(missile.GetComponent<Collider2D>(), GetComponent<Collider2D>());
				
			
		}

		
		if(player)
		{
			
			Debug.Log("collided with player");
			
			
			DataStorage.Health += 100f;
			if(DataStorage.Health > DataStorage.MaxHealth)
			{
				DataStorage.Health = DataStorage.MaxHealth;
			}
			
			
			Destroy(this.gameObject);
		}
		
	}
	
	
}
