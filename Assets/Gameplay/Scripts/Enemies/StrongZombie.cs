using UnityEngine;
using System.Collections;

public class StrongZombie : Enemy {

	protected override void Awake () 
	{
		base.Awake();
		type = EnemyType.STRONG_ZOMBIE;
	}


}
