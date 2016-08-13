using UnityEngine;
using System.Collections;

public class DoubleZombie : Enemy {

    [SerializeField] Enemy leftPartPrefab;
    [SerializeField] Enemy rightPartPrefab;

    public override void Awake () 
    {
        base.Awake();
		type = EnemyType.DOUBLE_ZOMBIE;
    }

    public override void death() 
    {
        float spawnRange = 0.5f;
        Vector3 spawnTranslation = new Vector3(Random.Range(-spawnRange,spawnRange), Random.Range(-spawnRange,spawnRange), 0);
        Enemy enemy = (Enemy) Instantiate(leftPartPrefab, transform.position + spawnTranslation, transform.rotation);
        spawnTranslation = new Vector3(Random.Range(-spawnRange,spawnRange), Random.Range(-spawnRange,spawnRange), 0);
        enemy = (Enemy) Instantiate(rightPartPrefab, transform.position + spawnTranslation, transform.rotation);

        deathEvent();
        
        Destroy(gameObject);
    }

}
