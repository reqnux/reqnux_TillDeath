using UnityEngine;
using System.Collections;

public class InreasedMagazineSizeAbility : SpecialAbility {

	[SerializeField] int increasedMagazineSize;

	public override void init() {
		base.init ();
		player.Stats.BonusIncreasedMagazineSize += increasedMagazineSize;
	}
}
