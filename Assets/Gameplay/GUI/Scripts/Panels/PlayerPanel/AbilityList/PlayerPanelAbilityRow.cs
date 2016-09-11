using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerPanelAbilityRow : MonoBehaviour {

	SpecialAbility ability;

	public void setAbility(SpecialAbility abt)	{
		ability = abt;
		transform.FindChild ("AbilityName").GetComponentInChildren<Text> ().text = SpecialAbilitiesDescriptions.names[ability.EnumName];
	}

	public void unlockAbility() {
		if (GameObject.FindObjectOfType<Player> ().StatPoints >= SpecialAbility.POINTS_COST) {
			GameObject.FindObjectOfType<Player> ().StatPoints -= SpecialAbility.POINTS_COST;
			GameObject.FindObjectOfType<ActiveSpecialAbilities> ().addAbility (ability);
			ability.init ();
			transform.parent.GetComponent<PlayerPanelAbilityList> ().fillListWithRandomAbilities ();
		}
	}

	public SpecialAbility Ability {
		get{ return ability;}
	}
}
