using UnityEngine;
using System.Collections;

public class ZombieHole : Enemy {

	[SerializeField] protected float appearOnMapTime;

	protected override void Awake () {
		base.Awake();
		Invoke ("appearOnMap", appearOnMapTime);
	}

	public override void takeDamage(float damage)	{
		stats.CurrentHealth -= damage;
		if (stats.CurrentHealth <= 0)
			death();
	}

	public override void death() {
		deathEvent();
		disappear ();
	}

	void appearOnMap() {
		GetComponent<Animator> ().enabled = true;
		Invoke ("activateSpawner", GetComponent<Animator> ().GetCurrentAnimatorStateInfo (0).length);
	}

	void disappear() {
		GetComponents<CircleCollider2D> ()[0].enabled = false;
		GetComponents<CircleCollider2D> ()[1].enabled = false;
		GetComponent<Animator>().Play ("ZombieHoleDisappear");
		GetComponent<AudioSource> ().Play ();
		Destroy (gameObject, GetComponent<AudioSource> ().clip.length);
	}

	protected virtual void activateSpawner() {
		GetComponents<CircleCollider2D> ()[0].enabled = true;
		GetComponents<CircleCollider2D> ()[1].enabled = true;
		GetComponent<ZombieHoleSpawner> ().enabled = true;
	}

}
