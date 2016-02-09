using UnityEngine;
using System.Collections;

public class UnitMovement : MonoBehaviour {

    protected virtual void FixedUpdate () {
        move();
    }

    protected virtual void move() {

    }

    protected void lookAtTarget(Vector3 targetLocation) {
        Vector3 diff =  targetLocation - transform.position;
        diff.Normalize();

        float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rot_z - 90);
    }
}
