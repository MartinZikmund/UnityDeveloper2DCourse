﻿using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Experimental.UIElements;

[RequireComponent(typeof(Ball))]
public class DragLaunch : MonoBehaviour
{
    private Ball _ball;
    private Vector3 _startPosition;
    private Vector3 _endPosition;
    private float _startTime;
    private float _endTime;

    // Use this for initialization
    void Start()
    {
        _ball = GetComponent<Ball>();
    }

    public void MoveStart(float distance)
    {
        if (!_ball.InPlay)
        {
            _ball.transform.Translate(new Vector3(distance, 0, 0));
        }
    }

    public void DragStart()
    {
        _startPosition = Input.mousePosition;
        _startTime = Time.time;
    }

    public void DragEnd()
    {
        _endPosition = Input.mousePosition;
        _endTime = Time.time;

        float dragDuration = _endTime - _startTime;
        float launchSpeedX = (_endPosition.x - _startPosition.x) / dragDuration;
        float launchSpeedZ = (_endPosition.y - _startPosition.y) / dragDuration;
        var launchVelocity = new Vector3(launchSpeedX / 100, 0, launchSpeedZ / 100);
        _ball.Launch(launchVelocity);
    }
}