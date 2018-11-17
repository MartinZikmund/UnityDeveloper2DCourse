using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    private Rigidbody _rigidBody;
    private AudioSource _audioSource;

    [SerializeField] private Vector3 _launchSpeed;

    private Vector3 _startingPosition;
    private bool _inPlay;

    // Use this for initialization
    void Start()
    {
        _rigidBody = GetComponent<Rigidbody>();
        _audioSource = GetComponent<AudioSource>();
        _rigidBody.useGravity = false;
        _startingPosition = transform.position;
    }

    public void Launch(Vector3 velocity)
    {
        if (!InPlay)
        {
            InPlay = true;
            _rigidBody.useGravity = true;
            _rigidBody.velocity = velocity;
            _audioSource.Play();
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public bool InPlay { get; set; }

    public void Reset()
    {
        InPlay = false;
        transform.position = _startingPosition;
        transform.rotation = Quaternion.identity;
        _rigidBody.velocity = Vector3.zero;
        _rigidBody.angularVelocity = Vector3.zero;
        _rigidBody.useGravity = false;
    }
}
