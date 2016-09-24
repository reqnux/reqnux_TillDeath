using UnityEngine;
using System.Collections;

public class DodgingEnemyMovement : UnitMovement {

	Player player;
	Unit movingUnit;

	[SerializeField] float minDodgeAreaWidth;
	[SerializeField] float maxDodgeAreaWidth;
	float dodgeAreaWidth;

	[SerializeField] float minDirectionChangeTime;
	[SerializeField] float maxDirectionChangeTime;
	float directionChangeTime;
	float lastDirectionChangeTime;

	int dodgeDirection = 1; // 1 or -1

	void Awake() 
	{
		player = GameManager.Player;
		movingUnit = GetComponent<Unit>();
		randomizeMovement ();
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
		transform.Rotate (new Vector3 (0, 0, dodgeDirection * dodgeAreaWidth *Mathf.Sin (distanceToPlayer ())));
		GetComponent<Rigidbody2D>().velocity = transform.up * movingUnit.Stats.MovementSpeed/10;
		tryDirectionChange ();
	}

	void tryDirectionChange() {
		if (Time.timeSinceLevelLoad > lastDirectionChangeTime + directionChangeTime) {
			lastDirectionChangeTime = Time.timeSinceLevelLoad;
			dodgeDirection *= -1;
			directionChangeTime = Random.Range (minDirectionChangeTime, maxDirectionChangeTime);
		}
	}

	void randomizeMovement() {
		dodgeAreaWidth = Random.Range (minDodgeAreaWidth, maxDodgeAreaWidth);
		lastDirectionChangeTime = Random.Range (minDirectionChangeTime, maxDirectionChangeTime);
		directionChangeTime = Random.Range (minDirectionChangeTime, maxDirectionChangeTime);
	}

	float distanceToPlayer() {
		return (player.transform.position - transform.position).magnitude;
	}
}
