using UnityEngine;
using System.Collections;

public class StationaryRegenerationAbility : SpecialAbility {

	[SerializeField] int healthPerTick;
	[SerializeField] float timeBetweenTicks;
	float lastTickTime;

	Rigidbody2D playerRigidbody;

	public override void init () {
		base.init ();
		playerRigidbody = player.GetComponent<Rigidbody2D>();
	}

	void Update () {
		if (playerRigidbody.velocity == Vector2.zero) {
			if (Time.timeSinceLevelLoad > lastTickTime + timeBetweenTicks) {
				player.heal (healthPerTick);
				lastTickTime = Time.timeSinceLevelLoad;
			}
		} 
		else lastTickTime = Time.timeSinceLevelLoad;
	}
}
