using UnityEngine;
using System.Collections;

public class Enemy : Unit {

    public delegate void EnemyDeathEvent(Enemy enemy);
    public static event EnemyDeathEvent enemyDeathEvent;

	public override void Awake () 
    {
        base.Awake();
        stats.CurrentHealth = stats.MaxHealth;
	}

    public override void death() 
    {
        if (enemyDeathEvent != null)
            enemyDeathEvent(this);
        Destroy(gameObject);
    }
	
    public override void takeDamage(int damage)
    {
        stats.CurrentHealth -= damage;
        if (stats.CurrentHealth <= 0)
            death();
    }

}