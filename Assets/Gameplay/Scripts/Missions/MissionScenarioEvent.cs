using UnityEngine;
using System.Collections;

[System.Serializable]
public class MissionScenarioEvent {

	public enum SpawnType {INSTANT, OVER_TIME}

	public float startTime;
	public SpawnType spawnType;
	public float duration;
	public EnemyType enemyType;
	public int enemyCount;

	MissionSpawner spawner;
	float timeBetweenSpawns;
	float lastSpawnTime;
	bool finished;

	public void execute() {
		if (spawnType == SpawnType.INSTANT)
			spawner.spawnEnemy (enemyType);
		else if(Time.timeSinceLevelLoad > lastSpawnTime + timeBetweenSpawns)
			spawner.spawnEnemy (enemyType);
		checkFinish ();
	}

	public bool isActive() {
		return Time.timeSinceLevelLoad >= startTime && !finished;
	}

	void checkFinish() {
		if (spawnType == SpawnType.INSTANT || Time.timeSinceLevelLoad > startTime + duration)
			finished = true;
	}

	public MissionSpawner Spawner {
		set{spawner = value;}
	}
}