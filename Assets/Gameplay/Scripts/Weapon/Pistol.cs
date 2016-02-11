using UnityEngine;
using System.Collections;

public class Pistol : Weapon {

	public override void Awake () 
    {
        base.Awake();
	}
	
    public override void shoot()
    {
        Debug.Log("Pistol: shoot");
    }


}
