using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.UIElements.GraphView;
using UnityEngine;

public class GameSession : MonoBehaviour {
    private int score = 0;

    public static GameSession Instance { get; private set; } = null;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public int Score => score;

    public void AddToScore(int value)
    {
        score += value;
    }

    public void ResetGame()
    {
        Instance = null;
        Destroy(gameObject);
    }
}
