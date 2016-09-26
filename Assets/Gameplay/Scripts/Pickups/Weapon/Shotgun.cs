using UnityEngine;
using System.Collections;

public class Shotgun : Weapon {

	float gunEndingTranslation;
	Vector3 gunEndingPos;
	int randomAngle;

    protected override void Awake () 
    {
        base.Awake();
		gunEndingPos = gunEnding.localPosition;
		bulletsPerShot = 7;
		shotConeWidth = 30;
		randomAngle = 3;
    }

	public override void shoot() {
		if (canShoot())
		{
			gunEnding.Rotate(new Vector3(0, 0, -shotConeWidth / 2));
			for (int i = 0; i < bulletsPerShot; i++)
			{
				gunEndingTranslation = Random.Range (0f, 1f);
				gunEnding.localPosition = new Vector3(gunEnding.localPosition.x , gunEnding.localPosition.y + gunEndingTranslation,0);
				spawnBullet();
				gunEnding.localPosition = gunEndingPos;
				gunEnding.RotateAround(gunEnding.position, Vector3.forward, shotConeWidth / bulletsPerShot + Random.Range(-randomAngle, randomAngle));
			}
			gunEnding.localRotation = Quaternion.identity;

			weaponSound.playShotSound();
			lastShotTime = Time.time;
			currentAmmo--;
			if (currentAmmo == 0)
				reload();
		}
	}
}