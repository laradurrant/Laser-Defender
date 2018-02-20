using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreKeeper : MonoBehaviour {

	public Text winText;
	
	void Start()
	{
		
		
	}

	void FixedUpdate()
	{
		winText.text = "Score: " + DataStorage.Score;

	}
	
	

}
