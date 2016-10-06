using UnityEngine;
using System.Collections;

public abstract class UnitMovement : MonoBehaviour {

	protected Rigidbody2D unitRigidbody;

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

	protected abstract void move ();

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

	public static Quaternion lootAtTarget(Vector3 objLocation, Vector3 targetLocation) {
		Vector3 diff =  targetLocation - objLocation;
		diff.Normalize();

		float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
		return Quaternion.Euler(0f, 0f, rot_z - 90);
	}
}
