using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class GameTimer : MonoBehaviour
{
    [SerializeField] private float _levelSeconds = 100;

    private Slider _slider;
    private AudioSource _audioSource;
    private bool _isEndOfLevel = false;
    private LevelManager _levelManager;
    private GameObject _winLabel;

    // Use this for initialization
    void Start()
    {
        _slider = GetComponent<Slider>();
        _audioSource = GetComponent<AudioSource>();
        _levelManager = FindObjectOfType<LevelManager>();
        _winLabel = GameObject.Find("You Win");
        _winLabel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (!_isEndOfLevel && Time.timeSinceLevelLoad > _levelSeconds)
        {
            _audioSource.Play();
            Invoke("LoadNextLevel", _audioSource.clip.length);
            _isEndOfLevel = true;
            _winLabel.SetActive(true);
            DestroyAllTaggedObjects();
        }
        _slider.value = Time.timeSinceLevelLoad / _levelSeconds;
    }

    private void DestroyAllTaggedObjects()
    {
        var objects = GameObject.FindGameObjectsWithTag("DestroyOnWin");
        foreach (var obj in objects)
        {
            Destroy(obj);
        }
    }

    void LoadNextLevel()
    {
        _levelManager.LoadNextLevel();
    }
}
