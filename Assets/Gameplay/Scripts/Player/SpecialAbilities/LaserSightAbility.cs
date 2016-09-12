using UnityEngine;
using System.Collections;

public class LaserSightAbility : SpecialAbility {

	[SerializeField] GameObject laserSight;

	public override void init() {
		base.init ();
		GameObject laser = Instantiate (laserSight);
		laser.transform.parent = player.CurrentWeapon.GunEnding;
		laser.transform.localPosition = Vector3.zero;
		laser.transform.localEulerAngles = new Vector3 (0, 0, 90);
	}

}
