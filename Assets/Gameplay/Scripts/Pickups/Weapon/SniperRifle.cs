using UnityEngine;
using System.Collections;

public class SniperRifle : Weapon {

    protected override void Awake () 
    {
        base.Awake();
    }

    protected override void spawnBullet()
    {
        Rigidbody2D bullet = (Rigidbody2D) Instantiate(bulletPrefab, gunEnding.transform.position, gunEnding.transform.rotation);
        bullet.velocity = gunEnding.transform.up * bulletSpeed;

        bullet.GetComponent<Bullet>().Weapon = this;
    }
}