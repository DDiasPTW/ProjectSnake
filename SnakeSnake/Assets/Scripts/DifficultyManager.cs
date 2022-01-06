using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DifficultyManager : MonoBehaviour
{
    public float spawnSpeed = 0.4f;
    private float minSpawnSpeed = .05f;

    private void Update()
    {
        if (spawnSpeed > minSpawnSpeed)
        {
            spawnSpeed -= Time.deltaTime * 0.0012f; //after around 5 Minutes it should reach the min spawn speed (.05f)
        }
        else spawnSpeed = minSpawnSpeed;
        
    }
}
