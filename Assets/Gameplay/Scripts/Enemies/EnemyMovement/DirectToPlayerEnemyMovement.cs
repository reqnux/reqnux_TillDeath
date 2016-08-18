using UnityEngine;
using System.Collections;

public class DirectToPlayerEnemyMovement : UnitMovement {

	Player player;
	Unit movingUnit;

	void Start () {
		player = GameObject.Find("Player").GetComponent<Player>();
		movingUnit = GetComponent<Unit>();
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
		GetComponent<Rigidbody2D>().velocity = transform.up * movingUnit.Stats.MovementSpeed;
	}
}
