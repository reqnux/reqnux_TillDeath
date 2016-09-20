using UnityEngine;
using System.Collections;

public class ZombieHole : Enemy {

	[SerializeField] float appearOnMapTime;

	protected override void Awake () {
		base.Awake();
		Invoke ("appearOnMap", appearOnMapTime);
	}

	public override void takeDamage(int damage)	{
		stats.CurrentHealth -= damage;

		if (stats.CurrentHealth <= 0)
			death();
	}

	public override void death() {
		deathEvent();
		disappear ();
	}

	public void appearOnMap() {
		GetComponent<Animator> ().enabled = true;//.Play ("ZombieHoleAppear");
		Invoke ("activateSpawner", GetComponent<Animator> ().GetCurrentAnimatorStateInfo (0).length);
	}
	void disappear() {
		GetComponent<CircleCollider2D> ().enabled = false;
		GetComponent<Animator>().Play ("ZombieHoleDisappear");
		GetComponent<AudioSource> ().Play ();
		Destroy (gameObject, GetComponent<AudioSource> ().clip.length);
	}

	void activateSpawner() {
		GetComponent<ZombieHoleSpawner> ().enabled = true;
	}

}
