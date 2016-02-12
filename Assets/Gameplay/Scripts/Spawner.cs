using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {

    [SerializeField]  Enemy enemyPrefab;
    [SerializeField]  bool isActive = true;
    [SerializeField]  float timeBetweenSpawns; // in seconds
    private float lastSpawnTime;
	
    void Start()
    {
        Player.playerDeathEvent += disable;
    }

    void OnDisable()
    {
        Player.playerDeathEvent -= disable;
    }

    void Update()
    {
        if (isActive && Time.timeSinceLevelLoad > lastSpawnTime + timeBetweenSpawns)
        {
            spawnEnemy();
            lastSpawnTime = Time.timeSinceLevelLoad;
        }
    }

    void spawnEnemy()
    {
        Enemy enemy = (Enemy) Instantiate(enemyPrefab, transform.position, transform.rotation);
    }

    void disable()
    {
        isActive = false;
    }
}
