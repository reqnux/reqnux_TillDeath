using UnityEngine;
using System.Collections;

public class Shotgun : Weapon {

    [SerializeField] int bulletsPerShot = 7;
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

            lastShotTime = Time.time;
            currentAmmo--;
            if (currentAmmo == 0)
                reload();
        }
    }

    protected override void spawnBullet()
    {
        Rigidbody2D bullet = (Rigidbody2D) Instantiate(bulletPrefab, gunEnding.transform.position, gunEnding.transform.rotation);
        bullet.velocity = gunEnding.transform.up * bulletSpeed;

        bullet.GetComponent<Bullet>().Weapon = this;
    }

}