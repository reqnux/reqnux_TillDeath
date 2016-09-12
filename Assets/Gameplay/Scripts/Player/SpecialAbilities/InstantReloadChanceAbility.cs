using UnityEngine;
using System.Collections;

public class InstantReloadChanceAbility : SpecialAbility {

	[SerializeField] int instantReloadChance;

	public override void onReload() {
		if(Random.Range(0,100) < instantReloadChance)
			player.CurrentWeapon.TimeToReloadEnd = 0;
	}

}
