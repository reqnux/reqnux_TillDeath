using UnityEngine;
using System.Collections;

public class ElectricityGun : Weapon {

    [SerializeField] ElectricityChain effectPrefab;
    [SerializeField] float range = 2.0f;

    protected override void Awake () 
    {
        base.Awake();
    }

    public override void shoot()
    {
        if (canShoot())
        {
            lastShotTime = Time.time;
			RaycastHit2D hit = Physics2D.Raycast(gunEnding.position, gunEnding.up,range);
            ElectricityChain effect = (ElectricityChain)Instantiate(effectPrefab,gunEnding.position,gunEnding.rotation);

			if (hit.collider != null && hit.collider.tag == "Enemy")
				effect.initFromWeapon (this, hit.collider.transform);
            else 
                effect.GetComponent<ElectricityEffect>().DefaultLength = range;
        }
    }
    public override void reload(){} //electricityGun cant be reloaded
}