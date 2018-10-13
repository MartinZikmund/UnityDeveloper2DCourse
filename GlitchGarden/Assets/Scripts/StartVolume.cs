using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartVolume : MonoBehaviour
{
    private MusicManager _musicManager;
	// Use this for initialization
	void Start ()
	{
	    _musicManager = FindObjectOfType<MusicManager>();
	    if (_musicManager)
	    {
	        float volume = PlayerPrefsManager.MasterVolume;
            _musicManager.SetVolume( volume );
	    }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
