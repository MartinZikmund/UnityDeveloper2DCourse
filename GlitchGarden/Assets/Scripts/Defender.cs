using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class Defender : MonoBehaviour
{
    [SerializeField] public int StarCost = 10;

    private StarDisplay _starDisplay;

    private void Start()
    {
        _starDisplay = GameObject.FindObjectOfType<StarDisplay>();
    }

    public void AddStars(int amount)
    {
        _starDisplay.AddStars(amount);
    }
}
