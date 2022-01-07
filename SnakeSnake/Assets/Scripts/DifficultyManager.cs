using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DifficultyManager : MonoBehaviour
{
    public float spawnSpeed = 0.4f;
    [SerializeField]private float minSpawnSpeed = .08f;

    private void Update()
    {
        if (spawnSpeed > minSpawnSpeed)
        {
            spawnSpeed -= Time.deltaTime * 0.0011f; //after around 5 Minutes it should reach the min spawn speed (.08f), with the start speed of .4f
        }
        else spawnSpeed = minSpawnSpeed;
        
    }
}
