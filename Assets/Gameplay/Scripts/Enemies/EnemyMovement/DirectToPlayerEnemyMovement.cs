using UnityEngine;
using System.Collections;

public class DirectToPlayerEnemyMovement : UnitMovement {

	Player player;
	Unit movingUnit;

	void Start () {
		player = GameManager.Player;
		movingUnit = GetComponent<Unit>();
		unitRigidbody = GetComponent<Rigidbody2D> ();
	}
	
	protected override void OnEnable()
	{
		base.OnEnable();
	}

	protected override void OnDisable()
	{
		base.OnDisable();
	}

	protected override void move() 
	{
		lookAtTarget(player.transform.position);
		unitRigidbody.velocity = transform.up * movingUnit.Stats.MovementSpeed;
	}
}
