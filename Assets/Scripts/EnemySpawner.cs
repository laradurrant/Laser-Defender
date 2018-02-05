using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

  public GameObject prefab;
  public float width;
  public float height;
	
    void Start()
    {

		
		
		foreach ( Transform child in transform) {
			Instantiate(prefab, child.transform.position, Quaternion.identity);
		//	prefab.transform.parent = child;
			
		}
	
		
    }

	void OnDrawGizmos()
	{
		Gizmos.DrawWireCube(transform.position, new Vector3(width, height, 0));
		
	}
	
	
}
