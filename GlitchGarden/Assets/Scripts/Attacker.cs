using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacker : MonoBehaviour
{
    [Range(-1, 1.5f)]
    public float _walkSpeed;

    // Use this for initialization
    void Start()
    {
        var rigidBody = gameObject.AddComponent<Rigidbody2D>();
        rigidBody.isKinematic = true;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.left * _walkSpeed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log(name + " collided with " + other.gameObject.name);
    }    
}
