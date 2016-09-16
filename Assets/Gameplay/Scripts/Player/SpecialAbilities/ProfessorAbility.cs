using UnityEngine;
using System.Collections;

public class ProfessorAbility : SpecialAbility {

	[SerializeField] int bonusExpPercentage = 10;

	public override void init () {
		base.init ();
		player.Stats.BonusExperienceGained += bonusExpPercentage;
	}
}
