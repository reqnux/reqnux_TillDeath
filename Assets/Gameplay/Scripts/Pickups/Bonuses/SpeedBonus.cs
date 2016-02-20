using UnityEngine;
using System.Collections;

public class SpeedBonus : Bonus {

    [Range(0.0f,1.0f)] [SerializeField] float speedBoost;
    float calculatedSpeedBoost;

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
        calculatedSpeedBoost = player.Stats.BaseMovementSpeed * speedBoost;
        player.Stats.BonusMovementSpeed += (int)calculatedSpeedBoost;
    }
    public override void deactivate()
    {
        player.Stats.BonusMovementSpeed -= (int)calculatedSpeedBoost;
    }
}
