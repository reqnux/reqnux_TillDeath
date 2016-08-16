using UnityEngine;
using System.Collections;

public class MissionSpawner : Spawner {

	public void spawnEnemy(EnemyType type)
	{
		Enemy enemy = (Enemy) Instantiate(getEnemyByType(type), getSpawnPosition(), transform.rotation);
	}

	public void spawnEnemies(EnemyType type, int count)
	{
		for(int i = 0; i < count; i++)
			Instantiate(getEnemyByType(type), getSpawnPosition(), transform.rotation);
	}
   
}