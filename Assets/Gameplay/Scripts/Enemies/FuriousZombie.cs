using UnityEngine;
using System.Collections;

public class FuriousZombie : Enemy {

	public override void Awake () 
	{
		base.Awake();
		type = EnemyType.FURIOUS_ZOMBIE;
	}
}