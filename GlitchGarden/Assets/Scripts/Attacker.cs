using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacker : MonoBehaviour
{
    private float _currentSpeed;
    [SerializeField]
    [Tooltip("Average seconds")]
    public float _seenEverySeconds;
    private GameObject _currentTarget;

    private Animator _animator;

    // Use this for initialization
    void Start()
    {
        var rigidBody = gameObject.AddComponent<Rigidbody2D>();
        rigidBody.isKinematic = true;

        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.left * _currentSpeed * Time.deltaTime);

        if (!_currentTarget)
        {
            _animator.SetBool("isAttacking", false);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
    }

    public void SetSpeed(float speed)
    {
        _currentSpeed = speed;
    }

    public void StrikeCurrentTarget(float damage)
    {
        if (_currentTarget)
        {
            var health = _currentTarget.GetComponent<Health>();
            if (health)
            {
                health.DealDamage(damage);
            }
        }
    }

    public void Attack(GameObject o)
    {
        _currentTarget = o;
    }
}
