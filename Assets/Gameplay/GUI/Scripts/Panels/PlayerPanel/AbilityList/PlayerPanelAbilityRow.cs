using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerPanelAbilityRow : MonoBehaviour {

	SpecialAbility ability;
	Player player;

	void Awake() {
		player = GameObject.FindObjectOfType<Player> ();
	}

	public void setAbility(SpecialAbility abt)	{
		ability = abt;
		transform.FindChild ("AbilityName").GetComponentInChildren<Text> ().text = SpecialAbilitiesDescriptions.names[ability.EnumName];
	}

	public void unlockAbility() {
		if (player.StatPoints >= SpecialAbility.POINTS_COST) {
			player.StatPoints -= SpecialAbility.POINTS_COST;
			player.ActiveAbilities.addAbility (ability);
			SpecialAbility unlockedAbility = Instantiate (ability);
			unlockedAbility.transform.parent = player.transform.FindChild ("ActiveAbilities");
			unlockedAbility.transform.localPosition = Vector3.zero;
			unlockedAbility.init ();
			transform.parent.GetComponent<PlayerPanelAbilityList> ().fillListWithRandomAbilities ();
		}
	}

	public SpecialAbility Ability {
		get{ return ability;}
	}
}
