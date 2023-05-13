using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] enemyPrefabs; // An array of enemy prefabs to spawn
    public float minSpawnTime = 1f; // The minimum time between spawns
    public float maxSpawnTime = 5f; // The maximum time between spawns
    public float spawnRadius = 5f; // The maximum distance from the spawner at which the enemy can spawn
    public int maxEnemies = 5; // The maximum number of enemies to spawn
    private float nextSpawnTime; // The time at which the next enemy will spawn
    private int numEnemies = 0; // The current number of spawned enemies

    void Start()
    {
        // Initialize the next spawn time to a random value between minSpawnTime and maxSpawnTime
        nextSpawnTime = Time.time + Random.Range(minSpawnTime, maxSpawnTime);
    }

    void Update()
    {
        // Check if the current number of enemies is less than the maximum allowed
        if (numEnemies < maxEnemies)
        {
            // If the current time is greater than the next spawn time, spawn an enemy
            if (Time.time >= nextSpawnTime)
            {
                // Choose a random enemy prefab from the array
                int randomIndex = Random.Range(0, enemyPrefabs.Length);
                GameObject enemyPrefab = enemyPrefabs[randomIndex];

                // Choose a random position within the spawn radius
                Vector3 randomPosition = transform.position + Random.insideUnitSphere * spawnRadius;

                // Spawn the enemy at the random position
                Instantiate(enemyPrefab, randomPosition, Quaternion.identity);

                // Update the number of enemies
                numEnemies++;

                // Set the next spawn time to a random value between minSpawnTime and maxSpawnTime
                nextSpawnTime = Time.time + Random.Range(minSpawnTime, maxSpawnTime);
            }
        }
    }

    // This method is called when an enemy is destroyed
    public void OnEnemyDestroyed()
    {
        // Update the number of enemies
        numEnemies--;
    }
}