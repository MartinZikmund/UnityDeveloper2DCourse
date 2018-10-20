using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    private const string ProjectileParentName = "Projectiles";

    [SerializeField] private GameObject _projectile;
    [SerializeField] private GameObject _projectileParent;
    [SerializeField] private GameObject _gun;
    private Animator _animator;
    private Spawner _myLaneSpawner;

    // Use this for initialization
    void Start()
    {
        _projectileParent = GameObject.Find(ProjectileParentName);
        if (!_projectileParent)
        {
            _projectileParent = new GameObject(ProjectileParentName);
        }
        _animator = GetComponent<Animator>();
        SetMySpawner();
    }

    // Update is called once per frame
    void Update()
    {
        _animator.SetBool("isAttacking", IsAttackerAheadInLane());
    }

    void SetMySpawner()
    {
        var spawners = GameObject.FindObjectsOfType<Spawner>();
        foreach (var spawner in spawners)
        {
            if (Mathf.Approximately(spawner.transform.position.y, transform.position.y))
            {
                _myLaneSpawner = spawner;
            }
        }

        if (_myLaneSpawner == null)
        {
            Debug.LogError("No spawner in lane of " + name);
        }
    }

    private bool IsAttackerAheadInLane()
    {
        if (_myLaneSpawner.transform.childCount > 0)
        {
            foreach (Transform child in _myLaneSpawner.transform)
            {
                if (child.transform.position.x > transform.position.x)
                {
                    return true;
                }
            }
        }
        return false;
    }

    private void Fire()
    {
        var projectile = Instantiate(_projectile);
        projectile.transform.parent = _projectileParent.transform;
        projectile.transform.position = _gun.transform.position;
    }
}