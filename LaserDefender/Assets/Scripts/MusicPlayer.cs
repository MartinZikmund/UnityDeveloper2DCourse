using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{

    private static MusicPlayer _instance = null;

	// Use this for initialization
	void Awake () {
	    if (_instance == null)
	    {
	        _instance = this;
            DontDestroyOnLoad(gameObject);
	    }
	    else
	    {
            Destroy(gameObject);
	    }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
