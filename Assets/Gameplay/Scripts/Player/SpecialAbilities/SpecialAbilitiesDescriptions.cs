using UnityEngine;
using System.Collections.Generic;

public enum SpecialAbilityName {
	LaserSight
}

public class SpecialAbilitiesDescriptions {

	public static Dictionary<SpecialAbilityName,string> names = new Dictionary<SpecialAbilityName,string> () {
		{ SpecialAbilityName.LaserSight,"Laser sight" },

	};

	public static Dictionary<SpecialAbilityName,string> descriptions = new Dictionary<SpecialAbilityName,string> () {
		{ SpecialAbilityName.LaserSight,"You get laser sight to every weapon you use." },

	};
}
