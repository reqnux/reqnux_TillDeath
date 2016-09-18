using UnityEngine;
using System.Collections.Generic;

public class PlayerPanelAbilityList : MonoBehaviour {

	void Start () {
		fillListWithRandomAbilities ();
	}

	public void fillListWithRandomAbilities() {
		List<SpecialAbility> abilities = 
			GameObject.FindObjectOfType<SpecialAbilitiesList> ().getSetOfRandomNotActiveAbilities (transform.childCount);
		PlayerPanelAbilityRow[] rows = GetComponentsInChildren<PlayerPanelAbilityRow>();
		for (int i = 0; i < rows.Length; i++) {
			if (i < abilities.Count)
				rows [i].setAbility (abilities [i]);
			else
				rows [i].gameObject.SetActive (false);
		}
	}
}
