﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPathing : MonoBehaviour
{
    private WaveConfig waveConfig;
    private List<Transform> waypoints;    

    private int waypointIndex = 0;

    void Start()
    {
        waypoints = waveConfig.Waypoints;
        transform.position = waypoints[waypointIndex].transform.position;
    }

    void Update()
    {
        Move();

    }

    public void SetWaveConfig(WaveConfig waveConfig) => this.waveConfig = waveConfig;

    private void Move()
    {
        if (waypointIndex < waypoints.Count)
        {
            var targetPosition = waypoints[waypointIndex].transform.position;
            var movementThisFrame = waveConfig.MoveSpeed * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, movementThisFrame);
            if (transform.position == targetPosition)
            {
                waypointIndex++;
            }
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
