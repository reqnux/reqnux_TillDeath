using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {

	[SerializeField]  Enemy[] enemyPrefabs = null;
    [SerializeField]  bool isActive = true;
    float lastSpawnTime;
    float timeBetweenSpawns = 0;
	
    void Start()
    {
        GameManager.gameStopEvent += disable;
    }

    void OnDisable()
    {
        GameManager.gameStopEvent -= disable;
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
        Enemy enemy = (Enemy) Instantiate(enemyPrefabs[Random.Range(0,enemyPrefabs.Length)], transform.position, transform.rotation);
    }

    void disable()
    {
        isActive = false;
    }
}
