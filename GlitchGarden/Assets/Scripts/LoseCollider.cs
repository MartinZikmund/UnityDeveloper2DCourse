using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseCollider : MonoBehaviour
{

    private LevelManager _levelManager;
    private void Start()
    {
        _levelManager = FindObjectOfType<LevelManager>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        _levelManager.LoadLevel("03b Lose");
    }
}
