using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class EconomistAbility : SpecialAbility {

	[SerializeField] int newAbilityCost = 4;
	[SerializeField] Text abilityCostText;

	public override void init () {
		base.init ();
		SpecialAbility.POINTS_COST = newAbilityCost;
		abilityCostText = GameObject.Find ("AbilityCostText").GetComponent<Text> ();
		abilityCostText.text = "Ability cost: " + newAbilityCost + " points (Economist)";
	}
}
