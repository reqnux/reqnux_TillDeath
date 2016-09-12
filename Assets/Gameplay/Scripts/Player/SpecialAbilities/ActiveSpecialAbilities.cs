using UnityEngine;
using System.Collections.Generic;

public class ActiveSpecialAbilities : MonoBehaviour {

	public delegate void OnReloadEffects();
	public delegate void OnBulletHitEffects(Bullet bullet, Enemy enemyHit);
	public delegate void OnDamageTaken();
	public OnReloadEffects onReload;
	public OnBulletHitEffects onBulletHit;
	public OnDamageTaken onDamageTaken;

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
