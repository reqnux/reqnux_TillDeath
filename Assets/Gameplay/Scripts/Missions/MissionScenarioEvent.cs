using UnityEngine;
using System.Collections;

[System.Serializable]
public class MissionScenarioEvent {

	enum SpawnType {INSTANT, OVER_TIME}

	[SerializeField] float startTime;
	[SerializeField] SpawnType spawnType;
	[SerializeField] float duration;
	[SerializeField] float timeBetweenSpawns;
	[SerializeField] EnemyType enemyType;
	[SerializeField] int enemyCount;
	MissionSpawner spawner;
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