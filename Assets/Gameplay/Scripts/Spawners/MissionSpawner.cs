using UnityEngine;
using System.Collections;

public class MissionSpawner : Spawner {

	public void spawnEnemy(EnemyType type)
	{
		Enemy enemy = (Enemy) Instantiate(getEnemyByType(type), getSpawnPosition(), transform.rotation);
	}
   
}