using UnityEngine;
using System.Collections;

public class HugeZombieHole : ZombieHole {

	[SerializeField] bool shieldActive = true;

	protected override void Awake () {
		base.Awake();
	}
	
	public override void takeDamage(float damage)	{
		if (!shieldActive) {
			stats.CurrentHealth -= damage;
			GameManager.AudioManager.play (audioSourceHit, AudioType.ZombieHoleHit);
			if (stats.CurrentHealth <= 0)
				death ();
		}
	}
	protected override void activateSpawner() {
		base.activateSpawner ();
		transform.FindChild ("ZombieHoleShield").gameObject.SetActive (true);
		Invoke ("spawnFirstHugeZombie", 3);
	}

	public void onZombieHoleDestroyed() {
		if (GameObject.FindObjectsOfType<ZombieHole> ().Length == 1) {
			transform.FindChild ("ZombieHoleShield").gameObject.SetActive (false);
			shieldActive = false;
		}
	}

	void spawnFirstHugeZombie() {
		GetComponent<ZombieHoleSpawner> ().spawnEnemy (EnemyType.HUGE_ZOMBIE);
	}

}
