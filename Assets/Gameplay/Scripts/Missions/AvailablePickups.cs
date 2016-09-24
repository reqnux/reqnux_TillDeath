using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class AvailableItem {
	public PickableItem item;
	public bool available = true;
}

public class AvailablePickups : MonoBehaviour {

	[SerializeField] int weaponChance = 10;
	[SerializeField] List<AvailableItem> weapons;
	[SerializeField] List<AvailableItem> bonuses;

	public PickableItem getRandomItem() {
		if (!anyItemsAvailable ())
			return null;

		if (anyWeaponsAvailable() && Random.Range (0, 100) < weaponChance)
			return getRandomWeapon ();

		int i = Random.Range (0, bonuses.Count);
		while (!bonuses [i].available)
			i = Random.Range (0, bonuses.Count);
		return bonuses [i].item;
	}
	public Weapon getRandomWeapon() {
		if (!anyWeaponsAvailable ())
			return null;
		
		int i = Random.Range (0, weapons.Count);
		while (!weapons [i].available)
			i = Random.Range (0, weapons.Count);
		return (Weapon)weapons [i].item;
	}

	// returns true if at least one item is available
	public bool anyItemsAvailable() {
		foreach (AvailableItem i in bonuses) {
			if (i.available)
				return true;
		}
		return anyWeaponsAvailable();
	}

	bool anyWeaponsAvailable() {
		foreach (AvailableItem i in weapons) {
			if (i.available)
				return true;
		}
		return false;
	}
}