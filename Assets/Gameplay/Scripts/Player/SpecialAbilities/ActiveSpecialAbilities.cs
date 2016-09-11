using UnityEngine;
using System.Collections.Generic;

public class ActiveSpecialAbilities : MonoBehaviour {

	List<SpecialAbility> activeAbilities;

	void Awake() {
		activeAbilities = new List<SpecialAbility> ();
	}

	public void addAbility(SpecialAbility ability) {
		activeAbilities.Add (ability);
	}

	public List<SpecialAbility> ActiveAbilities {
		get{ return activeAbilities;}
	}

}
