using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowScore : MonoBehaviour {

	public Text showScore;
	private int highscore;

	// Use this for initialization
	void Start () {
		highscore = DataStorage.Score;
	}
	
	// Update is called once per frame
	void Update () {
		print(highscore);
	    highscore = DataStorage.Score;
		showScore.text = "Your Score: " + highscore;
	}
}
