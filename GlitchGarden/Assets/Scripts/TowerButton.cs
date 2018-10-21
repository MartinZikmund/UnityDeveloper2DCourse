using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TowerButton : MonoBehaviour
{
    [SerializeField]private GameObject _prefab;
    public static GameObject SelectedDefender { get; private set; }
    private TowerButton[] _allTowerButtons;
    private Text _costText;

	// Use this for initialization
	void Start ()
	{
	    _allTowerButtons = FindObjectsOfType<TowerButton>();
	    _costText = GetComponentInChildren<Text>();
	    _costText.text = _prefab.GetComponent<Defender>().StarCost.ToString();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnMouseDown()
    {
        foreach (var button in _allTowerButtons)
        {
            button.GetComponent<SpriteRenderer>().color = Color.gray;
        }

        GetComponent<SpriteRenderer>().color = Color.white;
        SelectedDefender = _prefab;
    }
}
