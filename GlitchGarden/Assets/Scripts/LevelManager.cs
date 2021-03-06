﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{

    public float _autoLoadNextLevelAfter;

    private void Start()
    {
        if (_autoLoadNextLevelAfter != 0)
        {
            Invoke("LoadNextLevel", _autoLoadNextLevelAfter);
        }
    }

	public void LoadLevel( string name)
	{
	    SceneManager.LoadScene(name);
	}

    public void Quit()
    {
        Application.Quit();
    }

    public void LoadNextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
