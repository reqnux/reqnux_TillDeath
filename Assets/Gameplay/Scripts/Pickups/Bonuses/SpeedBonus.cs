using UnityEngine;
using System.Collections;

public class SpeedBonus : Bonus {

    [SerializeField] int percentageSpeedBoost;
    float speedBoost;

    protected override void Start()
    {
        base.Start();
    }
	
    public override void pickup()
    {
        base.pickup();
    }

    public override void activate()
    {
        base.activate();
        speedBoost = player.Stats.BaseMovementSpeed * percentageSpeedBoost/100;
        player.Stats.BonusMovementSpeed += (int)speedBoost;
    }
    public override void deactivate()
    {
        player.Stats.BonusMovementSpeed -= (int)speedBoost;
    }
}
