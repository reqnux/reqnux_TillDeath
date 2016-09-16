using UnityEngine;
using System.Collections;

public class MedicAbility : SpecialAbility {

	[SerializeField] int increasedHealPercentage = 50;

	public override void init () {
		base.init ();
	}
	public override void onItemPickup(PickableItem item) {
		if(item is HealthBonus)
			((HealthBonus)item).HealthRecovered += ((HealthBonus)item).HealthRecovered * increasedHealPercentage / 100;
	}
}
