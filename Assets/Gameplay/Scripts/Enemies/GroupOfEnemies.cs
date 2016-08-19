using UnityEngine;
using System.Collections;

public class GroupOfEnemies : MonoBehaviour {

	EnemyInGroup[] enemiesInGroup; 
	void Awake() {
		enemiesInGroup = transform.GetComponentsInChildren<EnemyInGroup> ();
	}

	public void groupAttacked() {
		foreach (EnemyInGroup e in enemiesInGroup) {
			e.GetComponent<UnitMovement> ().enabled = true;
			e.enabled = false;
		}
	}
}
