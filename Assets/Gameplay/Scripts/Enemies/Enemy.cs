﻿using UnityEngine;
using System.Collections;

public enum EnemyType {ZOMBIE, FAST_ZOMBIE, STRONG_ZOMBIE, DOUBLE_ZOMBIE}

public class Enemy : Unit {

    public delegate void EnemyDeathEvent(Enemy enemy);
    public static event EnemyDeathEvent enemyDeathEvent;

    [SerializeField] Blood bloodPrefab;
	protected EnemyType type;
	protected AvailablePickups availablePickups;


	public override void Awake () 
    {
        base.Awake();
		availablePickups = GameObject.FindObjectOfType<AvailablePickups> ();
        stats.CurrentHealth = stats.MaxHealth;
	}

    public override void death() 
    {
        dropRandomItem();
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
	protected void dropRandomItem()
	{
		if(Random.Range(0,100) < stats.ItemDropChance)
			Instantiate(availablePickups.getRandomItem(), transform.position, Quaternion.identity);
	}

	public EnemyType Type {
		get{ return type;}
	}
}