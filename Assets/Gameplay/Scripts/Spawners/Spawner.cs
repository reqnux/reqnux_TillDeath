using UnityEngine;
using System.Collections;

public abstract class Spawner : MonoBehaviour {

	[SerializeField] protected Enemy[] enemyPrefabs = null;
	[SerializeField] protected bool isActive = true;
	protected Map map;
	
	protected virtual void Start()
    {
        GameManager.gameStopEvent += disable;
		map = GameObject.FindObjectOfType<Map>();
    }

	protected virtual void OnDisable()
    {
        GameManager.gameStopEvent -= disable;
    }

    protected void spawnRandomEnemy()
    {
		Enemy enemy = (Enemy) Instantiate(enemyPrefabs[Random.Range(0,enemyPrefabs.Length)], getSpawnPosition(), transform.rotation);
    }

	protected Vector3 getSpawnPosition()
	{
		float x, y;
		if (Random.value > 0.5f)
		{
			x = map.XMovementRange + 1;
			y = Random.Range(-map.YMovementRange - 1, map.YMovementRange + 1);
			if (Random.value > 0.5f)
				x *= -1;
		}
		else
		{
			x = Random.Range(-map.XMovementRange - 1, map.XMovementRange + 1);
			y = map.YMovementRange + 1;
			if (Random.value > 0.5f)
				y *= -1;
		}
		return new Vector3(x, y, 0);
	}

	protected Enemy getEnemyByType(EnemyType type) {
		foreach (Enemy e in enemyPrefabs) {
			if (e.Type == type)
				return e;
		}
		Debug.LogError ("MissionSpawner.getEnemyByType() : enemyPrefabs does not contain this type of enemy " + type.ToString ());
		return null;
	}

    protected void disable()
    {
        isActive = false;
    }
}
