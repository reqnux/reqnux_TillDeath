using UnityEngine;
using System.Collections;

public class ZombieHoleShield : MonoBehaviour {

	ShieldEffect shieldEffect;
	ZombieHole parentHole;

	void Awake() {
		shieldEffect = transform.FindChild ("ShieldEffect").GetComponent<ShieldEffect>();
		parentHole = transform.parent.GetComponent<ZombieHole> ();
	}

	void OnTriggerEnter2D(Collider2D col) {
		if (col.tag == "Bullets") {
			shieldEffect.transform.rotation = 
				UnitMovement.lootAtTarget (shieldEffect.transform.position, GameManager.Player.transform.position);
			if (!shieldEffect.isActiveAndEnabled)
				shieldEffect.enabled = true;
			else
				shieldEffect.playEffect ();
			//if GranadeBullet hit the shield, make it explode
			if (col.GetComponent<GranadeBullet> () != null)
				col.GetComponent<GranadeBullet> ().hit (parentHole);
			col.gameObject.SetActive (false);
		}
	}
}
