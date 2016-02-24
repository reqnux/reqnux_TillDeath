using UnityEngine;
using System.Collections;

public class MissionSpawner : MonoBehaviour {

    [SerializeField]  bool isActive = true;
    [SerializeField]  int totalMonstersInMission;
    [SerializeField]  float initialMonstersPerMinute = 20;
    [SerializeField]  float MpMPerMinuteGrow = 5; // MonstersPerMinute per minute grow
    [SerializeField]  Enemy[] enemyPrefabs;

    float monstersPerMinute;
    float timeBetweenSpawns; // in seconds
    float lastSpawnTime;
    int spawnedMonstersCount;

    Map map;

    void Start()
    {
        GameManager.gameStopEvent += disable;
        map = GameObject.FindObjectOfType<Map>();
        monstersPerMinute = initialMonstersPerMinute;
    }

    void OnDisable()
    {
        GameManager.gameStopEvent -= disable;
    }

    void Update()
    {
        if (isActive && Time.timeSinceLevelLoad > lastSpawnTime + getTimeBetweenSpawns())
        {
            if (spawnedMonstersCount < totalMonstersInMission)
            {
                spawnEnemy();
                spawnedMonstersCount++;
                lastSpawnTime = Time.timeSinceLevelLoad;
                monstersPerMinute = getMonstersPerMinute();    
            }
            else
                gameObject.SetActive(false);

        }
    }

    void spawnEnemy()
    {
        Enemy enemy = (Enemy) Instantiate(enemyPrefabs[Random.Range(0,enemyPrefabs.Length)], getSpawnPosition(), transform.rotation);
    }

    Vector3 getSpawnPosition()
    {
        float x, y;
        if (Random.value > 0.5f)
        {
            x = map.XMovementRange + 1;
            y = Random.Range(-map.YMovementRange - 1, map.YMovementRange + 1);
            if (Random.value > 0.5f)
                x *= -1;
        }
        else
        {
            x = Random.Range(-map.XMovementRange - 1, map.XMovementRange + 1);
            y = map.YMovementRange + 1;
            if (Random.value > 0.5f)
                y *= -1;
        }
        return new Vector3(x, y, 0);
    }

    float getTimeBetweenSpawns()
    {
        return 60/monstersPerMinute;
    }
    float getMonstersPerMinute()
    {
        if (Time.timeSinceLevelLoad / 60 > 1)
        {
            float secondsBetweenMpMGrow = 60 / MpMPerMinuteGrow;

            return initialMonstersPerMinute + Time.timeSinceLevelLoad / 60 * MpMPerMinuteGrow;
        }
        return initialMonstersPerMinute;
    }

    void disable()
    {
        isActive = false;
    }
}
