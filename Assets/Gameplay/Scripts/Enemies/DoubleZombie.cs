using UnityEngine;
using System.Collections;

public class DoubleZombie : Enemy {

	float splitRange = 0.5f;

	protected override void Awake () 
    {
        base.Awake();
		type = EnemyType.DOUBLE_ZOMBIE;
    }

    public override void death() 
    {
		Vector3 spawnTranslation = transform.right * splitRange;
		Enemy enemy = EnemiesPool.pool.getEnemy(EnemyType.ZOMBIE_PART_RIGHT);
		enemy.transform.position = transform.position + spawnTranslation;
		enemy.transform.rotation = Quaternion.identity;
		enemy.gameObject.SetActive (true);

		spawnTranslation = -transform.right * splitRange;
		enemy = EnemiesPool.pool.getEnemy(EnemyType.ZOMBIE_PART_LEFT);
		enemy.transform.position = transform.position + spawnTranslation;
		enemy.transform.rotation = Quaternion.identity;
		enemy.gameObject.SetActive (true);

        deathEvent();
		gameObject.SetActive (false);
		reset ();
    }

}
