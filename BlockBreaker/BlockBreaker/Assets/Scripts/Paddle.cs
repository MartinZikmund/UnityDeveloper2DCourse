using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    [SerializeField] private float screenWidthInWorldUnits = 16;

    [SerializeField] private float minPosition = 1f;
    [SerializeField] private float maxPosition = 15f;

    // Update is called once per frame
    void Update()
    {
        var mousePositionInUnits = Input.mousePosition.x / Screen.width * screenWidthInWorldUnits;
        var paddlePosition = new Vector2(gameObject.transform.position.x, gameObject.transform.position.y);
        paddlePosition.x = Mathf.Clamp(mousePositionInUnits, minPosition, maxPosition);
        gameObject.transform.position = paddlePosition;
    }
}
