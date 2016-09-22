using UnityEngine;
using System.Collections;

public class FollowPlayerRadiusEnemyMovement : UnitMovement {

    Player player;
    Unit movingUnit;

    [SerializeField] float aggroRange = 3;
    [SerializeField] float chaseTime = 1; //chase time after entering aggroRange

	float baseRadius; // map.XMovementRange / 2
	Vector3 basePointToFollow;
	Vector3 currentPointToFollow;

	Map map;
	Vector3 movementDirection;
    bool flagChasing;
    float chaseAwakeTime;

    void Awake() {
		player = GameManager.Player;
        movingUnit = GetComponent<Unit>();
		unitRigidbody = GetComponent<Rigidbody2D> ();
		map = GameObject.FindObjectOfType<Map>();
		baseRadius = map.XMovementRange/2;

		randomizeMovement ();
		setBasePointToFollow();
		setCurrentPointToFollow (distanceToPlayer ());
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
					setCurrentPointToFollow (distanceToPlayer ());
					movementDirection = player.transform.position + currentPointToFollow;
                } else {
                    movementDirection = player.transform.position;
                }
            } 
            else {
				setCurrentPointToFollow (distanceToPlayer ());
				movementDirection = player.transform.position + currentPointToFollow;
            }
        }
        lookAtTarget(movementDirection);
		unitRigidbody.velocity = transform.up * movingUnit.Stats.MovementSpeed;
    }

	void setBasePointToFollow() {
		float x = Random.Range (-baseRadius, baseRadius);
		float y = Random.Range (-baseRadius, baseRadius);
		Vector3 direction = new Vector3 (x, y, 0);
		direction.Normalize();
		basePointToFollow = direction * baseRadius;
	}
	void setCurrentPointToFollow(float radius) {
		radius = Mathf.Clamp (radius, aggroRange, baseRadius);
		radius -= 0.3f;
		currentPointToFollow = basePointToFollow.normalized * radius;
	}

	void randomizeMovement() {
		float randomisationPercentage = 0.20f;
		baseRadius = baseRadius + Random.Range (-baseRadius * randomisationPercentage, baseRadius * randomisationPercentage);
		aggroRange = aggroRange + Random.Range (-aggroRange * randomisationPercentage, aggroRange * randomisationPercentage);
		chaseTime = chaseTime + Random.Range (-chaseTime * randomisationPercentage, chaseTime * randomisationPercentage); 
	}

    bool ifPlayerInAggro() {
		return ( distanceToPlayer() <= aggroRange);
    }

	float distanceToPlayer() {
		return (player.transform.position - transform.position).magnitude;
	}
}
