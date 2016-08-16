using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class AvailableItem {
	public PickableItem item;
	public bool available = true;
}

public class AvailablePickups : MonoBehaviour {

	public List<AvailableItem> pickups;

	public PickableItem getRandomItem() {
		if (!itemsAvailable ())
			return null;

		int i = Random.Range (0, pickups.Count);
		while (!pickups [i].available)
			i = Random.Range (0, pickups.Count);
		return pickups [i].item;
	}

	// returns true if at least one item is available
	public bool itemsAvailable() {
		foreach (AvailableItem i in pickups) {
			if (i.available)
				return true;
		}
		return false;
	}
}