using UnityEngine;
using System.Collections;

public class MissionSpawner : Spawner {

	public void spawnEnemy(EnemyType type)
	{
		Enemy enemy = EnemiesPool.pool.getEnemy(type);
		enemy.transform.position = getSpawnPosition();
		enemy.transform.rotation = Quaternion.identity;
		enemy.gameObject.SetActive (true);
	}

	public void spawnEnemies(EnemyType type, int count)
	{
		for (int i = 0; i < count; i++) {
			Enemy enemy = EnemiesPool.pool.getEnemy(type);
			enemy.transform.position = getSpawnPosition();
			enemy.transform.rotation = Quaternion.identity;
			enemy.gameObject.SetActive (true);
		}
	}
   
}