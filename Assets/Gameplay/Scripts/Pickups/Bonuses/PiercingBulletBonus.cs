using UnityEngine;
using System.Collections;

public class PiercingBulletBonus  : Bonus {

    [SerializeField] Rigidbody2D piercingBulletPrefab;

    Weapon currentWeapon;
    Rigidbody2D currentWeaponBullet;

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
            currentWeaponBullet = currentWeapon.BulletPrefab;
            currentWeapon.BulletPrefab = piercingBulletPrefab;
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
        currentWeaponBullet = currentWeapon.BulletPrefab;
        currentWeapon.BulletPrefab = piercingBulletPrefab;
    }
    public override void deactivate()
    {
        player.CurrentWeapon.BulletPrefab = currentWeaponBullet;

    }
}
