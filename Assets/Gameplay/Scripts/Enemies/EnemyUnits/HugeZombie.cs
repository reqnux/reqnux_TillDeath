using UnityEngine;
using System.Collections;

public class HugeZombie : Enemy {

	[SerializeField] float maxMovementSpeedGained = 10;
	float baseMovementSpeed;
	protected override void Awake () 
	{
		base.Awake();
		type = EnemyType.HUGE_ZOMBIE;
		baseMovementSpeed = stats.BaseMovementSpeed;
	}

	public override void takeDamage(float damage)
	{
		base.takeDamage (damage);
		if (stats.CurrentHealth > 0)
			recalculateMovementSpeed ();
	}

	void recalculateMovementSpeed() {
		float precentageHealthMissing = 1 - (float)stats.CurrentHealth / (float)stats.MaxHealth;
		stats.BaseMovementSpeed = baseMovementSpeed +  maxMovementSpeedGained * precentageHealthMissing;
	}
}
