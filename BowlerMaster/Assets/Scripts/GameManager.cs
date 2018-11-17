using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    private List<int> _bowls = new List<int>();

    private PinSetter _pinSetter;
    private Ball _ball;

    void Start ()
    {
        _pinSetter = GameObject.FindObjectOfType<PinSetter>();
        _ball = GameObject.FindObjectOfType<Ball>();
    }

    public void Bowl(int pinFall)
    {
        _bowls.Add(pinFall);

        var action = ActionMaster.NextAction(_bowls);
        _pinSetter.PerformAction(action);

        _ball.Reset();
    }
}
