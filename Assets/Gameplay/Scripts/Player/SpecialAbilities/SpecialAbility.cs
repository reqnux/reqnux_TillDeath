using UnityEngine;
using System.Collections;

public abstract class SpecialAbility : MonoBehaviour {
	
	public static int POINTS_COST = 5;

	[SerializeField] SpecialAbilityName enumName;
	
	public virtual void init () {
		ActiveSpecialAbilities activeAbilities = GameObject.FindObjectOfType<ActiveSpecialAbilities> ();
		activeAbilities.onReload += onReload;
		activeAbilities.onBulletHit += onBulletHit;
		activeAbilities.onDamageTaken += onDamageTaken;
	}

	public virtual void onReload(){}
	public virtual void onBulletHit(Bullet bullet, Enemy enemyHit){}
	public virtual void onDamageTaken(){}

	public SpecialAbilityName EnumName {
		get{ return enumName;}
	}
}
