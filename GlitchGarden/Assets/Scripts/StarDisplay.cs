using System.Collections;
using System.Collections.Generic;
using UnityEngine;using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class StarDisplay : MonoBehaviour
{
    private Text _starText;
    private int _stars = 100;

    public enum Status
    {
        Success,
        Failure
    }

    // Use this for initialization
	void Start ()
	{
	    _starText = GetComponent<Text>();
        UpdateText();
	}
	
	// Update is called once per frame
	void UpdateText ()
	{
	    _starText.text = _stars.ToString();
	}

    public void AddStars( int amount )
    {
        _stars += amount;
        UpdateText();
    }

    public Status UseStars(int amount)
    {
        if (_stars >= amount)
        {
            _stars -= amount;
            UpdateText();
            return Status.Success;
        }
        return Status.Failure;
    }
}
