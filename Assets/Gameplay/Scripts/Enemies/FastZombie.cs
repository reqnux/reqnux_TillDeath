﻿using UnityEngine;
using System.Collections;

public class FastZombie : Enemy {

    public override void Awake () 
    {
        base.Awake();
		type = EnemyType.FAST_ZOMBIE;
    }


}

