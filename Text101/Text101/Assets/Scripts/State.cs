using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "State")]
public class State : ScriptableObject
{
    [TextArea(14, 10)]
    [SerializeField]
    private string _storyText;

    [SerializeField]
    private State[] _nextStates;

    public string GetStateStory() => _storyText;

    public State[] GetNextStates() => _nextStates;
}
