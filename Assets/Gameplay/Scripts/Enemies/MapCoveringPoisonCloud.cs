using UnityEngine;
using System.Collections;

public class MapCoveringPoisonCloud : PoisonCloud {

	bool playerInSafeZone = true;

	protected override void Start () {}

	void Update() {
		if (!playerInSafeZone)
			dealDamage (GameManager.Player);
	}

	protected override void OnTriggerEnter2D(Collider2D col) {
		if (col.tag == "Player")
			playerInSafeZone = true;
	}

	protected override void OnTriggerStay2D(Collider2D col) {}

	protected void OnTriggerExit2D(Collider2D col) {
		if (col.tag == "Player")
			playerInSafeZone = false;
	}

}
