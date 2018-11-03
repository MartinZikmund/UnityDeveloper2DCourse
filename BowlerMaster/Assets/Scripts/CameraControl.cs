using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{

    [SerializeField] private Ball _ball;
    private Vector3 _offset;

	// Use this for initialization
	void Start ()
	{
	    _offset = transform.position - _ball.transform.position;
	}
	
	// Update is called once per frame
	void Update ()
	{
	    if (_ball.transform.position.z < 17.29) //in front of head pin
	    {
	        transform.position = _ball.transform.position + _offset;
        }	    
	}
}
