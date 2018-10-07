using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class OptionsController : MonoBehaviour
{
    public Slider _volumeSlider;
    public Slider _difficultySlider;
    public LevelManager _levelManager;

    private MusicManager _musicManager;

    private void Start()
    {
        _musicManager = FindObjectOfType<MusicManager>();

        _volumeSlider.value = PlayerPrefsManager.MasterVolume;
        _difficultySlider.value = PlayerPrefsManager.Difficulty;
    }

    private void Update()
    {
        _musicManager.SetVolume(_volumeSlider.value);
    }

    public void SaveAndExit()
    {
        PlayerPrefsManager.MasterVolume = _volumeSlider.value;
        PlayerPrefsManager.Difficulty = ( int )_difficultySlider.value;
        _levelManager.LoadLevel("01a Start");
    }
    
    public void SetDefaults()
    {
        _volumeSlider.value = 0.8f;
        _difficultySlider.value = 2f;
    }
}
