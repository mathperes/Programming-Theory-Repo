using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{

    public GameObject[] enemyPrefabs;
    public GameObject powerup;

    private float zEnemySpawn = 20.0f;
    private float zPowerupRange = 5.0f;
    private float xSpawnRange = 11.0f;
    private float ySpawn = 0.75f;

    private float spawnDelay = 1.5f;
    private float EnemySpawnTime = 2.5f;
    private float PowerupSpawnTime = 30.0f;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnEnemies", spawnDelay, EnemySpawnTime);
        InvokeRepeating("SpawnPowerups", spawnDelay, PowerupSpawnTime);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void SpawnEnemies()
    {
        int enemyIndex = Random.Range(0, enemyPrefabs.Length);
        Vector3 spawnPos = new Vector3(Random.Range(-xSpawnRange, xSpawnRange), ySpawn, zEnemySpawn);

        Instantiate(enemyPrefabs[enemyIndex], spawnPos, enemyPrefabs[enemyIndex].transform.rotation);
    }

    void SpawnPowerups()
    {
        float RandomX = Random.Range(-xSpawnRange, xSpawnRange);
        float RandomZ = Random.Range(-zPowerupRange, zPowerupRange);

        Vector3 spawnPos = new Vector3(RandomX, ySpawn, RandomZ);

        Instantiate(powerup, spawnPos, powerup.transform.rotation);
    }
}
