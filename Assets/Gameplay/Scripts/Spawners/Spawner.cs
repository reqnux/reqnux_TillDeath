using UnityEngine;
using System.Collections;

public enum SpawnSide {ANY, TOP, BOT, RIGHT, LEFT}

public abstract class Spawner : MonoBehaviour {

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

	protected void spawnRandomEnemy(SpawnSide side)
    {
		Enemy enemy = EnemiesPool.pool.getRandomEnemy();
		enemy.transform.position = getSpawnPosition(side);
		enemy.transform.rotation = Quaternion.identity;
		enemy.gameObject.SetActive (true);
    }

	protected Vector3 getSpawnPosition(SpawnSide side)
	{
		float x = 0;
		float y = 0;

		if (side == SpawnSide.ANY)
			side = (SpawnSide)Random.Range (1, SpawnSide.GetNames (typeof(SpawnSide)).Length);

		switch (side) {
			case SpawnSide.TOP:
				y = map.YMovementRange + 1; x = Random.Range(-map.XMovementRange - 1, map.XMovementRange + 1); break;
			case SpawnSide.BOT:
				y = -map.YMovementRange - 1; x = Random.Range(-map.XMovementRange - 1, map.XMovementRange + 1); break;
			case SpawnSide.RIGHT: 
				x = map.XMovementRange + 1; y = Random.Range(-map.YMovementRange - 1, map.YMovementRange + 1); break;
			case SpawnSide.LEFT:
				x = -map.XMovementRange - 1; y = Random.Range(-map.YMovementRange - 1, map.YMovementRange + 1); break;
		}
		return new Vector3(x, y, 0);
	}

    public void disable()
    {
        isActive = false;
    }
}
