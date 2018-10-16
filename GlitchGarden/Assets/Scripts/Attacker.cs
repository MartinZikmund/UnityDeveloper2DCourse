using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacker : MonoBehaviour
{
    private float _currentSpeed;
    private GameObject _currentTarget;

    // Use this for initialization
    void Start()
    {
        var rigidBody = gameObject.AddComponent<Rigidbody2D>();
        rigidBody.isKinematic = true;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.left * _currentSpeed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log(name + " collided with " + other.gameObject.name);
    }

    public void SetSpeed(float speed)
    {
        _currentSpeed = speed;
    }

    public void StrikeCurrentTarget(float damage)
    {
        Debug.Log(name + " done damage " + damage);
    }

    public void Attack(GameObject o)
    {
        _currentTarget = o;
    }
}
