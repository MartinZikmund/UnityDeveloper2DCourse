using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    private List<int> _bowls = new List<int>();

    private PinSetter _pinSetter;
    private Ball _ball;
    private ScoreDisplay _scoreDisplay;

    void Start ()
    {
        _pinSetter = GameObject.FindObjectOfType<PinSetter>();
        _ball = GameObject.FindObjectOfType<Ball>();
        _scoreDisplay = GameObject.FindObjectOfType<ScoreDisplay>();
    }

    public void Bowl(int pinFall)
    {
        _bowls.Add(pinFall);

        var action = ActionMaster.NextAction(_bowls);
        _pinSetter.PerformAction(action);

        _scoreDisplay.FillRollCard(_bowls);
        _scoreDisplay.FillFrames(ScoreMaster.ScoreCumulative(_bowls));
        _ball.Reset();
    }
}
