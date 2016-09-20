using UnityEngine;
using System.Collections;

public class LifeSavingExperienceAbility : SpecialAbility {

	[SerializeField] int lifeRecoveredPercentage = 5;

	public override void init () {
		base.init ();
		Player.playerLevelUpEvent += onLevelUp;
	}

	void onLevelUp() {
		player.heal (player.Stats.MaxHealth * lifeRecoveredPercentage / 100);
	}
	void OnDisable() {
		Player.playerLevelUpEvent -= onLevelUp;
	}
}
