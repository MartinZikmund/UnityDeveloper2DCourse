using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    [SerializeField] private GameObject[] _attackerPrefabs;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	    foreach (var attacker in _attackerPrefabs)
	    {
	        if (IsTimeToSpawn(attacker))
	        {
                Spawn(attacker);
	        }
	    }
	}

    void Spawn(GameObject attacker)
    {
        GameObject newAttacker = Instantiate(attacker);
        newAttacker.transform.parent = transform;
        newAttacker.transform.position = transform.position;
    }

    bool IsTimeToSpawn(GameObject attacker)
    {
        var attackerScript = attacker.GetComponent<Attacker>();
        var meanSpawnDelay = attackerScript._seenEverySeconds;
        var spawnsPerSecond = 1 / meanSpawnDelay;
        if (Time.deltaTime > meanSpawnDelay)
        {
            Debug.LogWarning("Too few frames per seconds, pausing spawning");
        }

        float threshold = spawnsPerSecond * Time.deltaTime / 5;

        return Random.value < threshold;
    }
}
