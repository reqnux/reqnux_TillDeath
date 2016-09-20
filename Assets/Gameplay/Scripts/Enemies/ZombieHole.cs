using UnityEngine;
using System.Collections;

public class ZombieHole : Enemy {

	[SerializeField] float appearOnMapTime;

	protected override void Awake () {
		base.Awake();
		Invoke ("appearOnMap", appearOnMapTime);
	}

	// Bullet detection here, because kinematic rigidbody colliders(bullets int this case) can't detect 
	// collision with another kinematic rigidbodies, so ZombieHole has to detect bullets on it's own.
	// ZombieHole triggers only StandardBullets, because PiercingBullets can detect ZombieHole.
	void OnTriggerEnter2D(Collider2D col) {
		if (col.tag == "Bullets") {
			col.gameObject.GetComponent<Bullet> ().hit (this);
		}
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
		GetComponents<CircleCollider2D> ()[0].enabled = false;
		GetComponents<CircleCollider2D> ()[1].enabled = false;
		GetComponent<Animator>().Play ("ZombieHoleDisappear");
		GetComponent<AudioSource> ().Play ();
		Destroy (gameObject, GetComponent<AudioSource> ().clip.length);
	}

	void activateSpawner() {
		GetComponents<CircleCollider2D> ()[0].enabled = true;
		GetComponents<CircleCollider2D> ()[1].enabled = true;
		GetComponent<ZombieHoleSpawner> ().enabled = true;
	}

}
