using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Enemy Wave Config")]
public class WaveConfig : ScriptableObject
{
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private GameObject pathPrefab;
    [SerializeField] private float timeBetweenSpawns = 0.5f;
    [SerializeField] float spawnRandomFactor = 0.3f;
    [SerializeField] private int numberOfEnemies = 5;
    [SerializeField] private float moveSpeed = 2f;

    public GameObject EnemyPrefab => enemyPrefab;

    public List<Transform> Waypoints
    {
        get
        {
            var waveWaypoints = new List<Transform>();
            foreach (Transform child in pathPrefab.transform)
            {
                waveWaypoints.Add(child);
            }
            return waveWaypoints;
        }
    }

    public float TimeBetweenSpawns => timeBetweenSpawns;

    public float SpawnRandomFactor => spawnRandomFactor;

    public int NumberOfEnemies => numberOfEnemies;

    public float MoveSpeed => moveSpeed;
}
