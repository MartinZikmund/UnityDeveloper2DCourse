using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerButton : MonoBehaviour
{
    [SerializeField]private GameObject _prefab;
    public static GameObject SelectedDefender { get; private set; }
    private TowerButton[] _allTowerButtons;

	// Use this for initialization
	void Start ()
	{
	    _allTowerButtons = FindObjectsOfType<TowerButton>();
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
