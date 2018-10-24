using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    private Rigidbody _rigidBody;
    private AudioSource _audioSource;
    [SerializeField] private Vector3 _launchSpeed;
    

    // Use this for initialization
    void Start()
    {
        _rigidBody = GetComponent<Rigidbody>();
        _audioSource = GetComponent<AudioSource>();
        _rigidBody.useGravity = false;
        Launch(_launchSpeed);
    }

    private void Launch( Vector3 velocity )
    {
        _rigidBody.useGravity = true;
        _rigidBody.velocity = velocity;
        _audioSource.Play();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
