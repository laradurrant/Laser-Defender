using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

  public GameObject prefab;
  public Transform leftposition;
  public Transform rightposition;
  public Transform topposition;
  public Transform bleftposition;
  public Transform brightposition;
	
    void Start()
    {
		/*
        for (int i = -2; i < 3; i++)
        {
            Instantiate(prefab, new Vector3(i * 1.0F, 0, 0), Quaternion.identity);
			prefab.transform.parent = transform;
		}
		*/
		
		foreach ( Transform child in transform) {
			Instantiate(prefab, child.transform.position, Quaternion.identity);
			prefab.transform.parent = child;
			
		}
		
		/*
		Instantiate(prefab, leftposition.position, Quaternion.identity);
		Instantiate(prefab, rightposition.position, Quaternion.identity);
		Instantiate(prefab, topposition.position, Quaternion.identity);
		Instantiate(prefab, bleftposition.position, Quaternion.identity);
		Instantiate(prefab, brightposition.position, Quaternion.identity);
		*/
    }

}
