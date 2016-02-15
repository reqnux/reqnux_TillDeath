﻿using UnityEngine;
using System.Collections;

public class HealthBonus : Bonus {

    [SerializeField] int percentageHealthRecovered; // % of player's max health

    protected override void Start()
    {
        base.Start();
    }
	
    public override void pickup()
    {
        int health = player.Stats.MaxHealth * percentageHealthRecovered / 100;
        player.heal(health);
        destroy();
    }

}
