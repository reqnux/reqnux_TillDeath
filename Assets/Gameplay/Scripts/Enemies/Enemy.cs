using UnityEngine;
using System.Collections;

public enum EnemyType {ZOMBIE, FAST_ZOMBIE, STRONG_ZOMBIE, DOUBLE_ZOMBIE}

public class Enemy : Unit {

    public delegate void EnemyDeathEvent(Enemy enemy);
    public static event EnemyDeathEvent enemyDeathEvent;

    [SerializeField] Blood bloodPrefab;
	protected EnemyType type;
    protected ItemsDrop itemsDrop;


	public override void Awake () 
    {
        base.Awake();
        itemsDrop = GetComponent<ItemsDrop>();
        stats.CurrentHealth = stats.MaxHealth;
	}

    public override void death() 
    {
        itemsDrop.dropRandomItem();
        deathEvent();
        Destroy(gameObject);
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

	public EnemyType Type {
		get{ return type;}
	}
}