using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shredder : MonoBehaviour
{
    void OnTriggerEnter2D (Collider2D col)
     {
     Debug.Log("Laser destroyed");
     Destroy(col.gameObject);
     }
    
}