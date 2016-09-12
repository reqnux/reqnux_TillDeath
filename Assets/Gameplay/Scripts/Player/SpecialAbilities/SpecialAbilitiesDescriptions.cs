using UnityEngine;
using System.Collections.Generic;

public enum SpecialAbilityName {
	LaserSight,
	AdrenalineRush
}

public class SpecialAbilitiesDescriptions {

	public static Dictionary<SpecialAbilityName,string> names = new Dictionary<SpecialAbilityName,string> () {
		{ SpecialAbilityName.LaserSight,"Laser sight" },
		{ SpecialAbilityName.AdrenalineRush,"Adrenaline rush" },

	};

	public static Dictionary<SpecialAbilityName,string> descriptions = new Dictionary<SpecialAbilityName,string> () {
		{ SpecialAbilityName.LaserSight,"You get laser sight to every weapon you use." },
		{ SpecialAbilityName.AdrenalineRush,"After getting hit by a monster, adrenaline rushes through your veins and you get short burst of movement speed."},

	};
}
