using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spinner : MonoBehaviour
{

    [SerializeField] private float speedOnSpin = 1f;
	
	// Update is called once per frame
	void Update ()
	{
	    transform.Rotate(0, 0, speedOnSpin * Time.deltaTime);
	}
}
