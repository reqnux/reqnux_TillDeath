using UnityEngine;
using System.Collections;

public class SniperRifle : Weapon {

    protected override void Awake () 
    {
        base.Awake();
    }

    public override void shoot()
    {
        if (!flagReloading && currentAmmo > 0 && Time.time > lastShotTime + delayBetweenShots)
        {
            spawnBullet();
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