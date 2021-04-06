using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager
{
    public int points;
    // Start is called before the first frame update
    private GameManager()
    {
        points = 0;
    }

    private static GameManager _instance;

    public static GameManager GetInstance()
    {
        if (_instance == null)
        {
            _instance = new GameManager();
        }

        return _instance;
    }
}
