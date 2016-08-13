using UnityEngine;
using System.Collections;

public class SurvivalSpawner : Spawner {

    [SerializeField]  float initialMonstersPerMinute = 20;
    [SerializeField]  float MpMPerMinuteGrow = 5; // MonstersPerMinute per minute grow

    float monstersPerMinute;
    float timeBetweenSpawns; // in seconds
    float lastSpawnTime;

    protected override void Start()
    {
		base.Start ();
        monstersPerMinute = initialMonstersPerMinute;
    }

    void Update()
    {
        if (isActive && Time.timeSinceLevelLoad > lastSpawnTime + getTimeBetweenSpawns())
        {
            spawnRandomEnemy();
            lastSpawnTime = Time.timeSinceLevelLoad;
            monstersPerMinute = getMonstersPerMinute();
        }
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
}