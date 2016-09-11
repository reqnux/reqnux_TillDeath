using UnityEngine;
using System.Collections.Generic;

public class SpecialAbilitiesList : MonoBehaviour {

	[SerializeField] List<SpecialAbility> specialAbilities;
	List<SpecialAbility> activeAbilities;

	void Awake() {
		activeAbilities = GameObject.FindObjectOfType<ActiveSpecialAbilities> ().ActiveAbilities;
	}

	public SpecialAbility getRandomNotActiveAbility() {
		if (activeAbilities.Count == specialAbilities.Count)
			return null;
		SpecialAbility ability = specialAbilities[Random.Range(0,specialAbilities.Count)];
		while(activeAbilities.Contains(ability))
			ability = specialAbilities[Random.Range(0,specialAbilities.Count)];
		return ability;
	}

	public List<SpecialAbility> getSetOfRandomNotActiveAbilities(int setSize) {
		//return smaller set if there are no enough inactive abilities
		setSize = Mathf.Min(setSize,specialAbilities.Count - activeAbilities.Count);
		List<SpecialAbility> abilitiesSet = new List<SpecialAbility>(setSize);
		SpecialAbility ability;
		for (int i = 0; i < setSize; i++) {
			ability = getRandomNotActiveAbility ();
			while(abilitiesSet.Contains(ability))
				ability = getRandomNotActiveAbility ();
			abilitiesSet.Add (ability);
		}
		return abilitiesSet;
	}
}
