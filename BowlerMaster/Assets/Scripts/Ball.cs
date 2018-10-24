using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    private Rigidbody _rigidBody;
    private AudioSource _audioSource;
    [SerializeField] private float _launchSpeed;
    

    // Use this for initialization
    void Start()
    {
        _rigidBody = GetComponent<Rigidbody>();
        _audioSource = GetComponent<AudioSource>();

        _rigidBody.velocity = new Vector3(0, 0, _launchSpeed);
        _audioSource.Play();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
