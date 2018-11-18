using System.Collections;
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
            var xPos = Mathf.Clamp(_ball.transform.position.x + distance, -0.5f, 0.5f);
            var yPos = _ball.transform.position.y;
            var zPos = _ball.transform.position.z;
            _ball.transform.position = new Vector3(xPos, yPos, zPos);
        }
    }

    public void DragStart()
    {
        if (!_ball.InPlay)
        {
            _startPosition = Input.mousePosition;
            _startTime = Time.time;
        }
    }

    public void DragEnd()
    {
        if (!_ball.InPlay)
        {
            _endPosition = Input.mousePosition;
            _endTime = Time.time;

            float dragDuration = _endTime - _startTime;
            float launchSpeedX = (_endPosition.x - _startPosition.x) / dragDuration;
            float launchSpeedZ = (_endPosition.y - _startPosition.y) / dragDuration;
            var launchVelocity = new Vector3(launchSpeedX / 300, 0, launchSpeedZ / 100);
            _ball.Launch(launchVelocity);
        }
    }
}
