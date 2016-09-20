using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ZombieHoleSpawner : MonoBehaviour {

	[SerializeField] List<EnemyType> enemies;
	[SerializeField] float timeBetweenSpawns;
	float lastSpawnTime;
	GameObject spawnEffect;

	void Awake() {
		spawnEffect = transform.FindChild ("ZombieHoleSpawnEffect").gameObject;
	}

	void OnEnable() {
		lastSpawnTime = Time.timeSinceLevelLoad;
	}


	void Update() {
		if (Time.timeSinceLevelLoad > lastSpawnTime + timeBetweenSpawns) {
			spawnRandomEnemy ();
			lastSpawnTime = Time.timeSinceLevelLoad;
		}
	}

	void spawnRandomEnemy() {
		Enemy enemy = EnemiesPool.pool.getEnemy (enemies[Random.Range (0, enemies.Count)]);
		StartCoroutine ("playSpawnEffect");
		enemy.transform.position = transform.position;
		enemy.transform.rotation = Quaternion.identity;
		enemy.gameObject.SetActive (true);
	}

	IEnumerator playSpawnEffect() {
		spawnEffect.SetActive (true);
		yield return new WaitForSeconds (1);
		spawnEffect.SetActive (false);
	}

}
