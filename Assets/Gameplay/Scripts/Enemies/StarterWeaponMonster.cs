using UnityEngine;
using System.Collections;

public class StarterWeaponMonster : Enemy {

	[SerializeField] Weapon starterWeapon; 

	public override void Awake () 
	{
		base.Awake();
		type = EnemyType.ZOMBIE;
	}

	public override void death() 
	{
		Instantiate(starterWeapon, transform.position, Quaternion.identity);
		deathEvent();
		Destroy (gameObject);
	}
}
