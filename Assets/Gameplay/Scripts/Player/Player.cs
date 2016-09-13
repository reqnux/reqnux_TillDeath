﻿using UnityEngine;
using System.Collections;

public class Player : Unit {

    public delegate void PlayerDeathEvent();
    public static event PlayerDeathEvent playerDeathEvent;

    [SerializeField]  Weapon currentWeapon;
	ActiveSpecialAbilities activeAbilities;
	int statPoints = 5;

    float timeBetweenDamage = 0.5f;
    float lastDamageTakenTime;

    public override void Awake () 
    {
        base.Awake();
        stats.CurrentHealth = stats.MaxHealth;
		activeAbilities = GetComponent<ActiveSpecialAbilities> ();

		if (currentWeapon != null)
			useWeapon(currentWeapon);
		else
			Debug.LogError("Player : No default weapon assigned!");
    }

    public override void death() 
    {
        if(playerDeathEvent != null)
            playerDeathEvent();
    }

    public override void takeDamage(int damage)
    {
        if (Time.time > lastDamageTakenTime + timeBetweenDamage)
        {
            lastDamageTakenTime = Time.time;
			if(activeAbilities.onDamageTaken != null)
				activeAbilities.onDamageTaken();
            stats.CurrentHealth -= damage;
            if (stats.CurrentHealth <= 0)
                death();
        }
    }

    public void useWeapon(Weapon weapon)
    {
        currentWeapon = weapon;
        weapon.Player = this;
		weapon.CurrentAmmo = weapon.MagazineSize;
        stats.BaseDamage = weapon.Damage;
        // recalculate bonusDamage, based on active bonuses
    }

    public Weapon CurrentWeapon
    {
        get{return currentWeapon;} 
    }

	public int StatPoints {
		get{ return statPoints;}
		set{ statPoints = value;}
	}
	public ActiveSpecialAbilities ActiveAbilities {
		get{ return activeAbilities;}
	}

}
