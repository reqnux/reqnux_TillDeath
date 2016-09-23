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
	public SpawnSide spawnSide;

	MissionSpawner spawner;
	float timeBetweenSpawns = 1;
	float lastSpawnTime;
	int spawnedEnemies;
	bool finished;

	int enemiesPerSecondFloor;
	int enemiesLeft;
	float lastEnemiesLeftSpawnTime;
	float timeBetweenEnemiesLeftSpawns;

	public void init(MissionSpawner missionSpawner) {
		spawner = missionSpawner;
		enemiesPerSecondFloor = Mathf.FloorToInt(enemyCount / duration);
		enemiesLeft = enemyCount - Mathf.FloorToInt(enemiesPerSecondFloor * duration);
		if (enemiesLeft > 0)
			timeBetweenEnemiesLeftSpawns = duration / enemiesLeft;
	}

	public void execute() {
		if (spawnType == SpawnType.INSTANT)
			spawner.spawnEnemies (enemyType, enemyCount,spawnSide);
		else 
			executeOverTimeEvent ();
		checkFinish ();
	}

	void executeOverTimeEvent() {
		if (enemiesLeft > 0 && Time.timeSinceLevelLoad > lastEnemiesLeftSpawnTime + timeBetweenEnemiesLeftSpawns) {
			spawner.spawnEnemy (enemyType,spawnSide);
			lastEnemiesLeftSpawnTime = Time.timeSinceLevelLoad;
			spawnedEnemies++;
		}
		if (Time.timeSinceLevelLoad > lastSpawnTime + timeBetweenSpawns) {
			spawner.spawnEnemies (enemyType,enemiesPerSecondFloor,spawnSide);
			spawnedEnemies += enemiesPerSecondFloor;
			lastSpawnTime = Time.timeSinceLevelLoad;
		}
	}

	public bool isActive() {
		return Time.timeSinceLevelLoad >= startTime && !finished;
	}

	void checkFinish() {
		if (spawnType == SpawnType.INSTANT || enemyCount == spawnedEnemies)
			finished = true;
	}

	public bool isFinished() {
		return finished;
	}
}