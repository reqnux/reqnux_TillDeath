using UnityEngine;
using System.Collections;

public class Shotgun : Weapon {

    [SerializeField] new int bulletsPerShot = 7;
    [SerializeField] int shotConeWidth = 30; // degrees

    protected override void Awake () 
    {
        base.Awake();
    }

    public override void shoot()
    {
        if (canShoot())
        {
            gunEnding.Rotate(new Vector3(0, 0, -shotConeWidth / 2));
            for (int i = 0; i < bulletsPerShot; i++)
            {
                gunEnding.RotateAround(gunEnding.position, Vector3.forward, shotConeWidth / bulletsPerShot + Random.Range(-3, 3));
                spawnBullet();
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