using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pin : MonoBehaviour
{

    public float standingThreshold = 3f;

    private float _raiseDistance = 0.4f;
    private Rigidbody _rigidBody;

    // Use this for initialization
    void Start()
    {
        _rigidBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void Raise()
    {
        if (IsStanding())
        {
            _rigidBody.useGravity = false;
            transform.Translate(new Vector3(0, _raiseDistance, 0), Space.World);
        }
    }

    public void Lower()
    {
        transform.Translate(new Vector3(0, -_raiseDistance, 0), Space.World);
        _rigidBody.useGravity = true;
    }

    public bool IsStanding()
    {
        var rotationInEuler = transform.rotation.eulerAngles;

        var tiltInX = Mathf.Abs(Mathf.DeltaAngle(transform.rotation.eulerAngles.x, -90));
        var tiltInZ = Mathf.Abs(Mathf.DeltaAngle(rotationInEuler.z, 0));

        return tiltInX < standingThreshold && tiltInZ < standingThreshold;
    }
}
