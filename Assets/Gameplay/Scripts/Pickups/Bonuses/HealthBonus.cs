using UnityEngine;
using System.Collections;

public class HealthBonus : Bonus {

    [Range(0.0f,1.0f)][SerializeField] float healthRecovered; // % of player's max health

    protected override void Start()
    {
        base.Start();
    }
	
    public override void pickup()
    {
        destroy();
    }

    public override void activate()
    {
        int health = (int)(player.Stats.MaxHealth * healthRecovered);
        player.heal(health);
    }

}
