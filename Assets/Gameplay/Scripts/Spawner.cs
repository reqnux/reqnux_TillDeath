using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {

    [SerializeField] private Enemy enemyPrefab;

    [SerializeField] private float timeBetweenSpawns; // in seconds
    private float lastSpawnTime;
	
    void Update()
    {
        if (Time.time > lastSpawnTime + timeBetweenSpawns)
        {
            spawnEnemy();
            lastSpawnTime = Time.time;
        }
    }

    void spawnEnemy()
    {
        Enemy enemy = (Enemy) Instantiate(enemyPrefab, transform.position, transform.rotation);
    }
}
