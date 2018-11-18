using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using UnityEngine;
using UnityEngine.UI;

public class PinCounter : MonoBehaviour
{
    public Text standingDisplay;
    private int _lastStandingCount = -1;
    private int _lastSettledCount = 10;
    public bool _ballOutOfPlay = false;
    private GameManager _gameManager;
    private float _lastChangeTime;

    // Use this for initialization
    void Start()
    {
        _gameManager = GameObject.FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        var countStanding = CountStanding();
        standingDisplay.text = countStanding.ToString();
        if (_ballOutOfPlay)
        {
            CheckStanding(countStanding);
        }
    }

    public void Reset()
    {
        _lastSettledCount = 10;
    }

    void CheckStanding(int countStanding)
    {
        if (_lastStandingCount != countStanding)
        {
            _lastStandingCount = countStanding;
            _lastChangeTime = Time.time;
            return;
        }

        if (Time.time - _lastChangeTime > 3)
        {
            PinsHaveSettled();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.GetComponent<Ball>())
        {
            _ballOutOfPlay = true;
        }
    }

    void PinsHaveSettled()
    {
        int pinFall = _lastStandingCount - CountStanding();
        _lastStandingCount = CountStanding();
        _gameManager.Bowl(pinFall);

        _ballOutOfPlay = false;
        _lastSettledCount = 10;
        standingDisplay.color = Color.green;
    }

    public int CountStanding()
    {
        int standingPins = 0;

        foreach (var pin in GameObject.FindObjectsOfType<Pin>())
        {
            if (pin.IsStanding())
            {
                standingPins++;
            }
        }

        return standingPins;
    }
}
