using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    [SerializeField] private float screenWidthInWorldUnits = 16;

    [SerializeField] private float minPosition = 1f;
    [SerializeField] private float maxPosition = 15f;
    protected internal Ball ball;

    private void Start()
    {
        ball = FindObjectOfType<Ball>();
    }

    // Update is called once per frame
    void Update()
    {
            var paddlePosition = new Vector2(gameObject.transform.position.x, gameObject.transform.position.y);
            paddlePosition.x = Mathf.Clamp(GetXPos(), minPosition, maxPosition);
            gameObject.transform.position = paddlePosition;

    }

    private float GetXPos()
    {
        if (!GameSession.Instance.AutoPlay)
        {
            return Input.mousePosition.x / Screen.width * screenWidthInWorldUnits;
        }
        else
        {
            return ball.transform.position.x;
        }
    }
}
