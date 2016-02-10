using UnityEngine;
using System.Collections;

public class Pistol : Weapon {

	public override void Start () 
    {
        base.Start();
	}
	
    public override void shoot()
    {
        Debug.Log("Pistol: shoot");
    }


}
