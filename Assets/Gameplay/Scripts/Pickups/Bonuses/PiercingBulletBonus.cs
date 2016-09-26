using UnityEngine;
using System.Collections;

public class PiercingBulletBonus  : Bonus {

    Weapon currentWeapon;
	BulletType currentWeaponBulletType;

    protected override void Start()
    {
        base.Start();
    }
    protected override void Update()
    {
        base.Update();

        if (activated && currentWeapon != player.CurrentWeapon)
        {
            currentWeapon = player.CurrentWeapon;
			currentWeaponBulletType = currentWeapon.BulletType;
			currentWeapon.BulletType = BulletType.PIERCING;
        }
    }

    public override void pickup()
    {
        base.pickup();
    }

    public override void activate()
    {
        base.activate();
		currentWeapon = player.CurrentWeapon;
		currentWeaponBulletType = currentWeapon.BulletType;
		if (currentWeapon.BulletType != BulletType.GRANDADE) {
			currentWeapon.BulletType = BulletType.PIERCING;
		}
    }
    public override void deactivate()
    {
		player.CurrentWeapon.BulletType = currentWeaponBulletType;

    }
}
