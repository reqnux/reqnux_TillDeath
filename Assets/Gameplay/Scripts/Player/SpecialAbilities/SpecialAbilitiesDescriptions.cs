using UnityEngine;
using System.Collections.Generic;

public enum SpecialAbilityName {
	LaserSight,
	AdrenalineRush,
	InstantReloadChance,
	IncreasedMagazineSize,
	StationaryRegeneration,
	Economist,
	LifeSavingExperience,
	Medic,
}

public class SpecialAbilitiesDescriptions {

	public static Dictionary<SpecialAbilityName,string> names = new Dictionary<SpecialAbilityName,string> () {
		{ SpecialAbilityName.LaserSight,"Laser sight" },
		{ SpecialAbilityName.AdrenalineRush,"Adrenaline rush" },
		{ SpecialAbilityName.InstantReloadChance,"Instant reload chance" },
		{ SpecialAbilityName.IncreasedMagazineSize,"Increased magazine size" },
		{ SpecialAbilityName.StationaryRegeneration,"Stationary regeneration" },
		{ SpecialAbilityName.Economist,"Economist" },
		{ SpecialAbilityName.LifeSavingExperience,"Life saving experience" },
		{ SpecialAbilityName.Medic,"Medic" },

	};

	public static Dictionary<SpecialAbilityName,string> descriptions = new Dictionary<SpecialAbilityName,string> () {
		{ SpecialAbilityName.LaserSight,"You get laser sight to every weapon you use." },
		{ SpecialAbilityName.AdrenalineRush,"After getting hit by a monster, adrenaline rushes through your veins and you get short burst of movement speed."},
		{ SpecialAbilityName.InstantReloadChance,"You have 10% chance to instanly reload your weapon."},
		{ SpecialAbilityName.IncreasedMagazineSize,"Magazine size in every weapon is increased by 20%"},
		{ SpecialAbilityName.StationaryRegeneration,"When standing still, you slowly regenerate health."},
		{ SpecialAbilityName.Economist,"Other special abilities costs only 4 points." },
		{ SpecialAbilityName.LifeSavingExperience,"When leveling up, you recover 5% of your max health." },
		{ SpecialAbilityName.Medic,"Health bonus recovers 50% more health." },

	};
}
