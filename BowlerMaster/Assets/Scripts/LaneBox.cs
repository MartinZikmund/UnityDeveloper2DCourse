using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaneBox : MonoBehaviour {
    private PinSetter _pinSetter;

    // Use this for initialization
	void Start ()
	{
	    _pinSetter = FindObjectOfType<PinSetter>();
	}

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.GetComponent<Ball>())
        {
            _pinSetter._ballEnteredBox = true;
        }
    }
}
