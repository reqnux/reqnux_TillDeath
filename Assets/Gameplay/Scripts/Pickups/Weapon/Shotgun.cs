using UnityEngine;
using System.Collections;

public class Shotgun : Weapon {

    protected override void Awake () 
    {
        base.Awake();
		bulletsPerShot = 7;
		shotConeWidth = 30;
    }
}