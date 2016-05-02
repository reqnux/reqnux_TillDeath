using UnityEngine;
using System.Collections;

public class RandomEnemyMovement : UnitMovement {

    Player player;
    Unit movingUnit;

    [SerializeField]  float aggroRange = 5;
    [SerializeField]  float chaseTime = 4; //chase time after entering aggroRange
    Vector3 movementDirection;

    Map map;

    bool flagChasing;
    float chaseAwakeTime;

    void Awake() 
    {
        player = GameObject.Find("Player").GetComponent<Player>();
        map = GameObject.FindObjectOfType<Map>();
        movingUnit = GetComponent<Unit>();
        movementDirection = randomPoint();
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
                    movementDirection = randomPoint();
                } else {
                    movementDirection = player.transform.position;
                }
            } 
            else if ((transform.position - movementDirection).magnitude < 0.3f)
                movementDirection = randomPoint();
            
        }
        lookAtTarget(movementDirection);
        GetComponent<Rigidbody2D>().velocity = transform.up * movingUnit.Stats.MovementSpeed;
    }

    private Vector3 randomPoint() 
    {
        return new Vector3(Random.Range (-map.XMovementRange, map.XMovementRange),
            Random.Range (-map.YMovementRange, map.YMovementRange), 0);
    }

    private bool ifPlayerInAggro()
    {
        return ((player.transform.position - transform.position).magnitude <= aggroRange);
    }
}
