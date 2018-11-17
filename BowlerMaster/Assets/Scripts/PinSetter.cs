using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.UI;

public class PinSetter : MonoBehaviour
{    
    private Animator _animator = null;
    private PinCounter _pinCounter;

    [SerializeField] private GameObject _root;

    [SerializeField] private GameObject _pinSet;

    // Use this for initialization
    void Start()
    {
        _animator = GameObject.FindObjectOfType<Animator>();
        _pinCounter = GameObject.FindObjectOfType<PinCounter>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void RaisePins()
    {
        var pins = FindObjectsOfType<Pin>();
        foreach (var pin in pins)
        {
            pin.Raise();
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

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.GetComponent<Pin>())
        {
            Destroy(other.gameObject);
        }
    }

    public void PerformAction(ActionMaster.Action action)
    {        
        switch (action)
        {
            case ActionMaster.Action.Tidy:
                _animator.SetTrigger("tidyTrigger");
                break;
            case ActionMaster.Action.Reset:
                _animator.SetTrigger("resetTrigger");
                _pinCounter.Reset();
                break;
            case ActionMaster.Action.EndTurn:
                _animator.SetTrigger("resetTrigger");
                _pinCounter.Reset();
                break;
            case ActionMaster.Action.EndGame:
                _animator.SetTrigger("resetTrigger");
                break;
        }
    }
}
