using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class DataStorage
{

	private static int score = 0;

    public static int Score
    {
        get
        {
            return score;
        }
        set
        {
            score = value;
        }
    }
}
