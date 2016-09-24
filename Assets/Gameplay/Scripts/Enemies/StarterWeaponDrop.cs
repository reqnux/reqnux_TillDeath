using UnityEngine;
using System.Collections;

public class StarterWeaponDrop : MonoBehaviour {

	AvailablePickups availablePickups;

	void Awake() {
		availablePickups = GameObject.FindObjectOfType<AvailablePickups> ();
	}

	void OnEnable() {
		Enemy.enemyDeathEvent += dropWeapon;
	}

	void OnDisable() {
		Enemy.enemyDeathEvent -= dropWeapon;
	}

	void dropWeapon(Enemy enemy) {
		if (enemy.Stats.ItemDropChance > 0) {
			Weapon weapon = availablePickups.getRandomWeapon ();
			if (weapon != null) {
				// set this enemy item drop chance to 0 so it won't drop any item
				enemy.Stats.BaseItemDropChance = 0;
				Instantiate(weapon, enemy.transform.position, Quaternion.identity);
				enabled = false;
			}
		}
	}
}
