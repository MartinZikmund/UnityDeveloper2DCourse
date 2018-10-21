using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stone : MonoBehaviour
{
    private Animator _animator;

	// Use this for initialization
	void Start ()
	{
	    _animator = GetComponent<Animator>();
	}
	
    private void OnTriggerStay2D(Collider2D other)
    {
        var attacker = other.gameObject.GetComponent<Attacker>();
        if (attacker)
        {
            _animator.SetTrigger("underAttack trigger");
        }
    }
}
