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
	
	// Use this for initialization
	void Start () {
		//playerPosition = this.transform.position; 
		
	}
	
	void Fire()
	{
		GameObject beam = Instantiate(projectile, transform.position, Quaternion.identity) as GameObject;
			beam.GetComponent<Rigidbody2D>().velocity = new Vector3(0,projectileSpeed, 0);
	}
	
	void Update()
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
	
	// Update is called once per frame
	void FixedUpdate () {
		
		
		//print(playerPosition);
		
		if (Input.GetKey(KeyCode.LeftArrow))
		{
            print("Left button is held down");
			playerPosition = this.transform.position + (Vector3.left * speed * Time.deltaTime);
			transform.position = new Vector3(Mathf.Clamp(playerPosition.x, -6F, 6.0F), -3f, 0);
			
        }
		
        if (Input.GetKey(KeyCode.RightArrow))
		{
            print("Right button is held down");
			playerPosition = this.transform.position + (Vector3.right * speed * Time.deltaTime);
			transform.position = new Vector3(Mathf.Clamp(playerPosition.x, -6F, 6.0F), -3f, 0);
		}
	}
}
