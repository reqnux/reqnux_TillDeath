using UnityEngine;
using System.Collections;

public class Enemy : Unit {

	public override void Awake () 
    {
        base.Awake();
        stats.CurrentHealth = stats.MaxHealth;
	}

    public override void death() 
    {
        Destroy(gameObject);
    }
	
    public override void takeDamage(int damage)
    {
        stats.CurrentHealth -= damage;
        if (stats.CurrentHealth <= 0)
            death();
    }

}