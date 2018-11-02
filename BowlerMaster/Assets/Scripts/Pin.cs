using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pin : MonoBehaviour
{

    public float standingThreshold = 3f;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        print(IsStanding());
    }

    public bool IsStanding()
    {
        var rotationInEuler = transform.rotation.eulerAngles;

        var tiltInX = Mathf.Abs(Mathf.DeltaAngle(transform.rotation.eulerAngles.x, 0));
        var tiltInZ = Mathf.Abs(Mathf.DeltaAngle(rotationInEuler.z, 0));

        return tiltInX < standingThreshold && tiltInZ < standingThreshold;
    }
}
