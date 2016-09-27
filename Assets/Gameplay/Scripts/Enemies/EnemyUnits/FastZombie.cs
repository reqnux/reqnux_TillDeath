using UnityEngine;
using System.Collections;

public class FastZombie : Enemy {

	protected override void Awake () 
    {
        base.Awake();
		type = EnemyType.FAST_ZOMBIE;
    }
}