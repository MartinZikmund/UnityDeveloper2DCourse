using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerPrefsManager : MonoBehaviour
{
    private const string MasterVolumeKey = "masterVolume";
    private const string DifficultyKey = "difficulty";
    private const string LevelKey = "levelUnlocked";

    public static float MasterVolume
    {
        get
        {
            if (PlayerPrefs.HasKey(MasterVolumeKey))
            {
                return PlayerPrefs.GetFloat(MasterVolumeKey);
            }
            else
            {
                return 0.5f;
            }
        }
        set
        {
            if (value >= 0f && value <= 1f)
            {
                PlayerPrefs.SetFloat(MasterVolumeKey, value);
            }
            else
            {
                Debug.LogError("Can't set volume");
            }
        }
    }

    public static void UnlockLevel(int level)
    {
        if (level < SceneManager.sceneCountInBuildSettings)
        {            
            PlayerPrefs.SetInt(LevelKey + level, 1);
        }
        else
        {
            Debug.LogError("Can't unlock non-existing level");
        }
    }

    public static bool IsLevelUnlocked(int level)
    {
        bool isLevelUnlocked = PlayerPrefs.GetInt(LevelKey + level) == 1;
        if (level < SceneManager.sceneCountInBuildSettings)
        {
            return isLevelUnlocked;
        }
        return false;
    }

    public static int Difficulty
    {
        get
        {
            if (PlayerPrefs.HasKey(DifficultyKey))
            {
                return PlayerPrefs.GetInt(DifficultyKey);
            }
            else
            {
                return 2;
            }
        }
        set
        {
            if (value >= 1 && value <= 3)
            {
                //do it
                PlayerPrefs.SetInt(DifficultyKey, value);
            }
            else
            {
                Debug.LogError("Difficulty out of range");
            }
        }
    }
}
