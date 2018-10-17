using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{

    [SerializeField] private float _health;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void DealDamage(float damage)
    {
        _health -= damage;
        if (_health <= 0)
        {
            DestroyObject();
        }
    }

    private void DestroyObject() => Destroy(gameObject);
}
