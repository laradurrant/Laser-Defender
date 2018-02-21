using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class DataStorage
{

	private static int score = 0;
	private static float health = 500;
	private static float maxhealth = 500;
	
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
	
	public static float Health
    {
        get
        {
            return health;
        }
        set
        {
            health = value;
        }
    }
	
	public static float MaxHealth
    {
        get
        {
            return maxhealth;
        }
        set
        {
            maxhealth = value;
        }
    }
	
}
