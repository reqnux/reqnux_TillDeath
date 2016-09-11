using UnityEngine;
using System.Collections;

public class LaserSightAbility : SpecialAbility {

	[SerializeField] GameObject laserSight;

	public override void init() {
		GameObject laser = Instantiate (laserSight);
		laser.transform.parent = GameObject.FindObjectOfType<Player> ().CurrentWeapon.GunEnding;
		laser.transform.localPosition = Vector3.zero;
		laser.transform.localEulerAngles = new Vector3 (0, 0, 90);
		//laser.transform.Rotate (0, 0, 90);
	}

}
