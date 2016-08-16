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
		//check if at least one item is available
		int i = 0;
		while (i < pickups.Count && !pickups [i].available)
			i++;
		if (i >= pickups.Count)
			return null;

		i = Random.Range (0, pickups.Count);
		while (!pickups [i].available)
			i = Random.Range (0, pickups.Count);
		return pickups [i].item;
	}
}