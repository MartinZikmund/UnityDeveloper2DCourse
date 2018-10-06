using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicManager : MonoBehaviour
{
    private AudioSource _audioSource;

    [SerializeField] public AudioClip[] _levelMusicChangeArray;

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
        Debug.Log("Don't destroy me " + name);
        _audioSource = GetComponent<AudioSource>();
    }

    private void Start()
    {

    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += SceneManager_sceneLoaded;
    }

    private void SceneManager_sceneLoaded(Scene arg0, LoadSceneMode arg1)
    {
        var thisSceneMusic = _levelMusicChangeArray[arg0.buildIndex];
        Debug.Log("Playing clip " + thisSceneMusic);
        if (thisSceneMusic)
        {
            _audioSource.clip = thisSceneMusic;
            _audioSource.loop = true;
            _audioSource.Play();
        }
    }

    void OnDisable()
    {
        SceneManager.sceneLoaded -= SceneManager_sceneLoaded;
    }
}
