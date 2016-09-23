using UnityEngine;
using System.Collections;

public class MissionSpawner : Spawner {

	public void spawnEnemy(EnemyType type, SpawnSide side)
	{
		Enemy enemy = EnemiesPool.pool.getEnemy(type);
		enemy.transform.position = getSpawnPosition(side);
		enemy.transform.rotation = Quaternion.identity;
		enemy.gameObject.SetActive (true);
	}

	public void spawnEnemies(EnemyType type, int count, SpawnSide side)
	{
		for (int i = 0; i < count; i++) {
			Enemy enemy = EnemiesPool.pool.getEnemy(type);
			enemy.transform.position = getSpawnPosition(side);
			enemy.transform.rotation = Quaternion.identity;
			enemy.gameObject.SetActive (true);
		}
	}
   
}