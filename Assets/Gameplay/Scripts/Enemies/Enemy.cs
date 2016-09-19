using UnityEngine;
using System.Collections;

public enum EnemyType {
	ZOMBIE, 
	FAST_ZOMBIE,
	STRONG_ZOMBIE,
	DOUBLE_ZOMBIE, ZOMBIE_PART_RIGHT, ZOMBIE_PART_LEFT, 
	POISON_ZOMBIE, 
	FURIOUS_ZOMBIE
}

public class Enemy : Unit {

    public delegate void EnemyDeathEvent(Enemy enemy);
    public static event EnemyDeathEvent enemyDeathEvent;

    [SerializeField] Blood bloodPrefab;
	protected EnemyType type;
	protected Player player;
	protected AvailablePickups availablePickups;


	protected override void Awake () {
        base.Awake();
		player = GameManager.Player;
		availablePickups = GameObject.FindObjectOfType<AvailablePickups> ();
        stats.CurrentHealth = stats.MaxHealth;
	}

    public override void death() 
    {
        dropRandomItem();
        deathEvent();
		gameObject.SetActive (false);
		reset ();
    }
    
    public override void takeDamage(int damage)
    {
        stats.CurrentHealth -= damage;
        Instantiate(bloodPrefab, transform.position, transform.localRotation);

        if (stats.CurrentHealth <= 0)
            death();
    }

    protected void deathEvent()
    {
        if (enemyDeathEvent != null)
            enemyDeathEvent(this);
    }
	protected void dropRandomItem()
	{
		if (availablePickups.itemsAvailable() 
			&& Random.Range (0, 100) < stats.IncreasedItemDropChance + player.Stats.IncreasedItemDropChance) {
			Instantiate(availablePickups.getRandomItem(), transform.position, Quaternion.identity);
		}
	}

	protected void reset() {
		stats.CurrentHealth = stats.MaxHealth;
	}

	public EnemyType Type {
		get{ return type;}
	}

}