using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeIn : MonoBehaviour
{

    public float _fadeInTime;

    private Color _currentColor = Color.black;
    private Image _fadePanel;

	// Use this for initialization
	void Start ()
	{
	    _fadePanel = GetComponent<Image>();
	}
	
	// Update is called once per frame
	void Update () {
	    if (Time.timeSinceLevelLoad < _fadeInTime)
	    {
            //fade in
	        float alphaChange = Time.deltaTime / _fadeInTime;
	        float resultA =_currentColor.a - alphaChange;
	        _currentColor.a = Math.Max(0, resultA);
	        _fadePanel.color = _currentColor;
	    }
	    else
	    {
	        gameObject.SetActive(false);
	    }
	}
}
