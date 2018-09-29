using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class GameStatus : MonoBehaviour
{

    [SerializeField] [Range(0, 2)] private float gameSpeed = 1;
    [SerializeField] private int pointsPerBlockDestroyed = 83;
    [SerializeField] private Text scoreText;


    [SerializeField] private int currentScore = 0;

    public static GameStatus Instance { get; private set; }

    private void Awake()
    {        
        if (Instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    // Use this for initialization
    void Start()
    {
        UpdateScoreText();
    }

    private void UpdateScoreText()
    {
        scoreText.text = currentScore.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        Time.timeScale = gameSpeed;
    }

    public void AddToScore()
    {
        currentScore += pointsPerBlockDestroyed;
        UpdateScoreText();
    }
}
