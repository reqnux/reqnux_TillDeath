using UnityEngine;
using System.Collections;

public class UnitMovement : MonoBehaviour {

    protected virtual void OnEnable()
    {
        GameManager.gameStopEvent += disableMovement;
    }


    protected virtual void OnDisable()
    {
        GameManager.gameStopEvent -= disableMovement;
    }

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

    public void enableMovement()
    {
        this.enabled = true;
    }

    public void disableMovement()
    {
        GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        this.enabled = false;
    }
}
