using UnityEngine;
using System.Collections;

public class DoubleZombie : Enemy {

    public override void Awake () 
    {
        base.Awake();
		type = EnemyType.DOUBLE_ZOMBIE;
    }

    public override void death() 
    {
        float spawnRange = 0.5f;
        Vector3 spawnTranslation = new Vector3(Random.Range(-spawnRange,spawnRange), Random.Range(-spawnRange,spawnRange), 0);
		Enemy enemy = EnemiesPool.pool.getEnemy(EnemyType.ZOMBIE_PART_RIGHT);
		enemy.transform.position = transform.position + spawnTranslation;
		enemy.transform.rotation = Quaternion.identity;
		enemy.gameObject.SetActive (true);
        spawnTranslation = new Vector3(Random.Range(-spawnRange,spawnRange), Random.Range(-spawnRange,spawnRange), 0);
		enemy = EnemiesPool.pool.getEnemy(EnemyType.ZOMBIE_PART_LEFT);
		enemy.transform.position = transform.position + spawnTranslation;
		enemy.transform.rotation = Quaternion.identity;
		enemy.gameObject.SetActive (true);

        deathEvent();
		gameObject.SetActive (false);
    }

}
