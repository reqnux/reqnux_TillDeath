using UnityEngine;
using System.Collections;

public class Zombie : Enemy {

	protected override void Awake () 
    {
        base.Awake();
		type = EnemyType.ZOMBIE;
    }
}
