using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.UI;

public class PinSetter : MonoBehaviour
{
    private int _lastStandingCount = -1;
    private float _lastChangeTime;

    public Text standingDisplay;

    public bool _ballEnteredBox = false;
    private Ball _ball;
    private int _lastSettledCount = 10;
    private ActionMaster _actionMaster = new ActionMaster();
    private Animator _animator = null;

    [SerializeField] private GameObject _root;

    [SerializeField] private GameObject _pinSet;

    // Use this for initialization
    void Start()
    {
        _ball = GameObject.FindObjectOfType<Ball>();
        _animator = GameObject.FindObjectOfType<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        var countStanding = CountStanding();
        standingDisplay.text = countStanding.ToString();
        if (_ballEnteredBox)
        {
            CheckStanding(countStanding);
        }
    }

    public void RaisePins()
    {
        var pins = FindObjectsOfType<Pin>();
        foreach (var pin in pins)
        {
            pin.Raise();
            pin.transform.rotation = Quaternion.Euler(270, 0, 0);
        }
    }

    public void RenewPins()
    {
        var pinSet = Instantiate(_pinSet, new Vector3(0, 0, 18.29f), Quaternion.identity);

        pinSet.transform.parent = _root.transform;
        pinSet.transform.localScale = Vector3.one;
        foreach (Pin child in pinSet.GetComponentsInChildren<Pin>())
        {
            child.Raise();
        }
    }

    public void LowerPins()
    {
        var pins = FindObjectsOfType<Pin>();
        foreach (var pin in pins)
        {
            pin.Lower();
        }
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

    void PinsHaveSettled()
    {
        HandlePinFall();

        _ball.Reset();
        _ballEnteredBox = false;
        _lastStandingCount = -1;
        _lastSettledCount = 10;
        standingDisplay.color = Color.green;
    }

    private void HandlePinFall()
    {
        int pinFall = _lastSettledCount - CountStanding();
        _lastStandingCount = CountStanding();
        var action = _actionMaster.Bowl(pinFall);
        switch (action)
        {
            case ActionMaster.Action.Tidy:
                _animator.SetTrigger("tidyTrigger");
                break;
            case ActionMaster.Action.Reset:
                _animator.SetTrigger("resetTrigger");
                break;
            case ActionMaster.Action.EndTurn:
                _animator.SetTrigger("resetTrigger");
                break;
            case ActionMaster.Action.EndGame:
                _animator.SetTrigger("resetTrigger");
                break;
        }
    }



    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.GetComponent<Pin>())
        {
            Destroy(other.gameObject);
        }
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
