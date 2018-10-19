using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefendersSpawner : MonoBehaviour
{
    private const string DefenderParentName = "Defenders";
    public Camera myCamera;
    private GameObject _defenderParent;

    // Use this for initialization
	void Start () {
	    _defenderParent = GameObject.Find(DefenderParentName);
	    if (!_defenderParent)
	    {
	        _defenderParent = new GameObject(DefenderParentName);
	    }
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnMouseDown()
    {
        var gameObject = Instantiate(
            TowerButton.SelectedDefender, 
            SnapToGrid(CalculateWorldPointOfMouseClick()), 
            Quaternion.identity);
        gameObject.transform.parent = _defenderParent.transform;
    }

    Vector2 CalculateWorldPointOfMouseClick()
    {
        var mouseX = Input.mousePosition.x;
        var mouseY = Input.mousePosition.y;
        var distanceFromCamera = 10f;

        var weirdTriplet = new Vector3(mouseX, mouseY, distanceFromCamera);
        Vector2 worldPosition = myCamera.ScreenToWorldPoint(weirdTriplet);

        return worldPosition;
    }

    Vector2 SnapToGrid(Vector2 rawWorldPos)
    {
        float newX = Mathf.RoundToInt(rawWorldPos.x);
        float newY = Mathf.RoundToInt(rawWorldPos.y);
        return new Vector2(newX, newY);
    }
}
