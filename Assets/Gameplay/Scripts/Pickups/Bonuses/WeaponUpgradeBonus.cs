using UnityEngine;
using System.Collections;

public class WeaponUpgradeBonus : Bonus {

    [Range(0.0f,1.0f)] [SerializeField] float reducedReloadTime; // &
    [Range(0.0f,1.0f)] [SerializeField] float reducedTimeBetweenShots; // %

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
        player.Stats.BonusReducedReloadTime += reducedReloadTime;
        player.Stats.BonusReducedTimeBetweenShots += reducedTimeBetweenShots;
    }
    public override void deactivate()
    {
        player.Stats.BonusReducedReloadTime -= reducedReloadTime;
        player.Stats.BonusReducedTimeBetweenShots -= reducedTimeBetweenShots;
    }
}
