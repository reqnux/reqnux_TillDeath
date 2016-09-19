using UnityEngine;
using System.Collections;

public class ZombieHole : Unit {

	[SerializeField] float appearOnMapTime;

	protected override void Awake () {
		base.Awake();
		Invoke ("appearOnMap", appearOnMapTime);
	}

	public override void takeDamage(int damage)	{
		stats.CurrentHealth -= damage;

		if (stats.CurrentHealth <= 0)
			death();
	}

	public override void death() {
		Destroy (gameObject);
	}

	public void appearOnMap() {
		
	}
}
