using UnityEngine;
using System.Collections;

public class GranadeBullet : Bullet {

	[SerializeField] float explosionRange;
	Collider2D[] enemiesInRange;
	Explosion explosion;

	//called from outside only by KinematicEnemy script
	public override void hit(IDamageable objectHit) {
		enemiesInRange = Physics2D.OverlapCircleAll(transform.position, explosionRange);
		foreach(Collider2D e in enemiesInRange) {
			if (e.tag == "Enemy" && !e.isTrigger) {
				e.GetComponent<Enemy> ().takeDamage (weapon.Player.Stats.Damage);
				spawnBloodSplashEffect (e.gameObject);
			}
		}
		explosion = BulletsPool.pool.getExplosion ();
		explosion.transform.position = transform.position;
		explosion.gameObject.SetActive (true);
		deactivate ();
	}
}
