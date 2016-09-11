using UnityEngine;
using System.Collections;

public abstract class SpecialAbility : MonoBehaviour {
	
	public static int POINTS_COST = 5;

	[SerializeField] SpecialAbilityName enumName;

	void Awake () {

	}
	
	public abstract void init ();

	public SpecialAbilityName EnumName {
		get{ return enumName;}
	}
}
