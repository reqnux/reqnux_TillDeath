﻿using UnityEngine;
using System.Collections;

public class DefaultEnemyMovement : UnitMovement {

    private Player player;
    private Unit movingUnit;

    [SerializeField] private float aggroRange = 5;
    [SerializeField] private float chaseTime = 4; //chase time after entering aggroRange
    //how far player has to be from current movementDirection, to pick new movementDirection
    [SerializeField] private float targetResetDistance = 5; 
    private Vector3 movementDirection;

    private bool flagChasing;
    private float chaseAwakeTime;

    void Awake() 
    {
        player = GameObject.Find("Player").GetComponent<Player>();
        movingUnit = GetComponent<Unit>();
        movementDirection = pointBetweenPlayerAndEnemy();
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
                    movementDirection = pointBetweenPlayerAndEnemy ();
                } else {
                    movementDirection = player.transform.position;
                }
            } 
            else {
                if ((transform.position - movementDirection).magnitude < 0.3f 
                    || (player.transform.position - movementDirection).magnitude > targetResetDistance) {
                    movementDirection = pointBetweenPlayerAndEnemy ();
                }
            }
        }
        lookAtTarget(movementDirection);
        GetComponent<Rigidbody2D>().velocity = transform.up * movingUnit.Stats.MovementSpeed;
    }

    private Vector3 pointBetweenPlayerAndEnemy() 
    {
        return new Vector3(Random.Range (transform.position.x, player.transform.position.x),
                           Random.Range (transform.position.y, player.transform.position.y), 0);
    }

    private bool ifPlayerInAggro()
    {
        return ((player.transform.position - transform.position).magnitude <= aggroRange);
    }
}
