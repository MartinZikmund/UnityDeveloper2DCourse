using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{

    [SerializeField] private GameObject _projectile;
    [SerializeField] private GameObject _projectileParent;
    [SerializeField] private GameObject _gun;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void Fire()
    {
        var projectile = Instantiate(_projectile);
        projectile.transform.parent = _projectileParent.transform;
        projectile.transform.position = _gun.transform.position;
    }
}
