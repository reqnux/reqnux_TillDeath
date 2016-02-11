using UnityEngine;
using System.Collections;

public class Zombie : Enemy {

    public override void Awake () 
    {
        base.Awake();
        stats.MovementSpeed = 2;
        stats.Damage = 5;
        stats.MaxHealth = 5;
        stats.CurrentHealth = stats.MaxHealth;
    }
	

}
