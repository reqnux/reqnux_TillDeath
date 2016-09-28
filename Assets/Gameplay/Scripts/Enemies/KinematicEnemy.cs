using UnityEngine;
using System.Collections;

public class KinematicEnemy : MonoBehaviour {

	// Bullet detection here, because kinematic rigidbody colliders(bullets in this case) can't detect 
	// collision with another kinematic rigidbodies, so kinematic object has to detect bullets on it's own.
	// This script triggers only StandardBullets, because PiercingBullets can detect kinematic objects.
	Enemy enemy;

	void Awake() {
		enemy = GetComponent<Enemy>	();
	}

	void OnTriggerEnter2D(Collider2D col) {
		if (col.tag == "Bullets") {
			col.gameObject.GetComponent<Bullet> ().hit (enemy);
		}
	}
}
