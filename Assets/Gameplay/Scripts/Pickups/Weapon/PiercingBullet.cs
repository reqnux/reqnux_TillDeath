using UnityEngine;
using System.Collections.Generic;

public class PiercingBullet : Bullet {

    protected override void OnEnable() {
		base.OnEnable();
    }

    void OnTriggerEnter2D(Collider2D col) {
		if(col.gameObject.tag == "Enemy" && !col.isTrigger)
			col.gameObject.GetComponent<IDamageable>().takeDamage(weapon.Player.Stats.Damage);
    }

	// empty, beacuse PiercingBullet can detect all objects
	// and hit() is used only by ZombieHole
	public override void hit(IDamageable objectHit) {}

	public override Weapon Weapon {
		set { weapon = value;
			GetComponentInChildren<ParticleSystem> ().startSpeed = weapon.BulletSpeed*0.75f;}
	}
}
