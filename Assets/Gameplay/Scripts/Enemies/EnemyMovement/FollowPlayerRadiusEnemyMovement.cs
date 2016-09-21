using UnityEngine;
using System.Collections;

public class FollowPlayerRadiusEnemyMovement : UnitMovement {

    Player player;
    Unit movingUnit;

    [SerializeField]  float aggroRange = 3;
    [SerializeField]  float chaseTime = 1; //chase time after entering aggroRange

	[SerializeField]float bigRadius; // map.XMovementRange / 2
	[SerializeField]float smallRadius;
	float currentRadius;
	Vector3 currentPointToFollow;

	enum Radius {big,small};
	Radius radius;

	Map map;
	Vector3 movementDirection;
    bool flagChasing;
    float chaseAwakeTime;

    void Awake() 
    {
		player = GameManager.Player;
        movingUnit = GetComponent<Unit>();
		unitRigidbody = GetComponent<Rigidbody2D> ();
		map = GameObject.FindObjectOfType<Map>();
		bigRadius = map.XMovementRange/2;
		smallRadius = bigRadius * 0.75f;

		setPointToFollow();
		movementDirection = player.transform.position + currentPointToFollow;
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
        if (ifPlayerInAggro()) {
            if(!flagChasing) {
                flagChasing = true;
                chaseAwakeTime = Time.time;
            }
            movementDirection = player.transform.position;
        } else {
            if(flagChasing) {
                if(Time.time > chaseAwakeTime + chaseTime) {
                    flagChasing = false;
					setPointToFollow ();
					movementDirection = player.transform.position + currentPointToFollow;
                } else {
                    movementDirection = player.transform.position;
                }
            } 
            else {
				if (checkFollowPointChange ()) {
					setPointToFollow ();
				}
				movementDirection = player.transform.position + currentPointToFollow;
            }
        }
        lookAtTarget(movementDirection);
		unitRigidbody.velocity = transform.up * movingUnit.Stats.MovementSpeed;
    }

	bool checkFollowPointChange() {
		return (transform.position - movementDirection).magnitude < 0.3f
			|| (distanceToPlayer () <= smallRadius && radius == Radius.big)
			|| (distanceToPlayer () > smallRadius && radius == Radius.small);
	}

	void setPointToFollow() {
		setCurrentRadius ();
		float x = Random.Range (-currentRadius, currentRadius);
		float y = Random.Range (-currentRadius, currentRadius);
		Vector3 direction = new Vector3 (x, y, 0);
		direction.Normalize();
		currentPointToFollow = direction * currentRadius;
	}

	void setCurrentRadius() {
		if (distanceToPlayer () > smallRadius) {
			currentRadius = bigRadius + Random.Range (-bigRadius / 10, bigRadius / 10);
			radius = Radius.big;
		} else {
			currentRadius = smallRadius + Random.Range (-smallRadius / 10, smallRadius / 10);
			radius = Radius.small;
		}
	}

    bool ifPlayerInAggro() {
		return ( distanceToPlayer() <= aggroRange);
    }

	float distanceToPlayer() {
		return (player.transform.position - transform.position).magnitude;
	}
}
