using UnityEngine;
using System.Collections;

public class MultiShotBonus : Bonus {

	Weapon currentWeapon;
	FireMode currentWeaponMode;
	int currentWeaponBulletsPerShot;
	[SerializeField] int additionalBullets = 2;

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
			currentWeaponMode = currentWeapon.FireMode;
			currentWeaponBulletsPerShot = player.CurrentWeapon.BulletsPerShot;
			currentWeapon.FireMode = FireMode.MULTIPLE_FIXED;
			currentWeapon.BulletsPerShot += 2;
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
		currentWeaponMode = currentWeapon.FireMode;
		currentWeaponBulletsPerShot = player.CurrentWeapon.BulletsPerShot;
		currentWeapon.FireMode = FireMode.MULTIPLE_FIXED;
		currentWeapon.BulletsPerShot += additionalBullets;
	}
	public override void deactivate()
	{
		player.CurrentWeapon.FireMode = currentWeaponMode;
		currentWeapon.BulletsPerShot -= additionalBullets;
	}
}
