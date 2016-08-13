using UnityEngine;
using System.Collections;

public class StrongZombie : Enemy {

	public override void Awake () 
	{
		base.Awake();
		type = EnemyType.STRONG_ZOMBIE;
	}


}
