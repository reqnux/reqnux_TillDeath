using UnityEngine;
using System.Collections;

public class EnemyInGroup : MonoBehaviour {

	Enemy enemy;
	Rigidbody2D enemyRigidBody;

	void Awake () {
		enemy = GetComponent<Enemy> ();
		enemyRigidBody = GetComponent<Rigidbody2D> ();
	}
	
	void Update () {
		if (enemy.Stats.CurrentHealth != enemy.Stats.MaxHealth || enemyRigidBody.velocity != Vector2.zero)
			transform.parent.GetComponent<GroupOfEnemies> ().groupAttacked ();
	}

	void OnDisable() {
		transform.parent.GetComponent<GroupOfEnemies> ().groupAttacked ();
	}
}
