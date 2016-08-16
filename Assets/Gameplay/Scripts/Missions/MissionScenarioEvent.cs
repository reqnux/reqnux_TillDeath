using UnityEngine;
using System.Collections;

[System.Serializable]
public class MissionScenarioEvent {
	static int x = 0;
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

	public void init(MissionSpawner missionSpawner) {
		spawner = missionSpawner;
	}

	public void execute() {
		if (spawnType == SpawnType.INSTANT)
			spawner.spawnEnemies (enemyType, enemyCount);
		else if (Time.timeSinceLevelLoad > lastSpawnTime + getTimeBetweenSpawns ()) {
			spawner.spawnEnemy (enemyType);
			x++;
			Debug.Log (x);
			lastSpawnTime = Time.timeSinceLevelLoad;
		}
		checkFinish ();
	}

	public bool isActive() {
		return Time.timeSinceLevelLoad >= startTime && !finished;
	}

	void checkFinish() {
		if (spawnType == SpawnType.INSTANT || Time.timeSinceLevelLoad > startTime + duration)
			finished = true;
	}

	float getTimeBetweenSpawns() {
		return duration / enemyCount;
	}
}