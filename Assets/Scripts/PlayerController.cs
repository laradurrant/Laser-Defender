using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	private Vector3 playerPosition;
	private Rigidbody2D rb;
	public float speed = 0.1f;

	
	
	// Use this for initialization
	void Start () {
		//playerPosition = this.transform.position; 
		
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
