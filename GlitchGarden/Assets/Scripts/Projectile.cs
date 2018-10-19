using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Projectile : MonoBehaviour
{

    [SerializeField] private float _speed;
    [SerializeField] private float _damage;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate(Vector3.right * _speed * Time.deltaTime);
	}

    private void OnTriggerEnter2D(Collider2D other)
    {
        var attacker = other.gameObject.GetComponent<Attacker>();
        var health = other.gameObject.GetComponent<Health>();

        if (attacker && health)
        {
            health.DealDamage(_damage);
            Destroy(gameObject);
        }
    }
}
