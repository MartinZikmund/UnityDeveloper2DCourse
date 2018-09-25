using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AdventureGame : MonoBehaviour
{
    [SerializeField]
    private Text _textComponent;

    [SerializeField]
    private State _startingState;

    private State _currentState;

    // Use this for initialization
    void Start()
    {
        _currentState = _startingState;
        _textComponent.text = _currentState.GetStateStory();
    }

    // Update is called once per frame
    void Update()
    {
        ManageState();
    }

    private void ManageState()
    {
        var nextStates = _currentState.GetNextStates();
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            _currentState = nextStates[0];
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            _currentState = nextStates[1];
        }
        _textComponent.text = _currentState.GetStateStory();
    }
}
