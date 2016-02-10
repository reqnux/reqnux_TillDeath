using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour {

    void Update()
    {
        transform.position = new Vector3(Mathf.Clamp(player.position.x,-xMovementRange,xMovementRange),
                                        Mathf.Clamp(player.position.y,-yMovementRange,yMovementRange),
                                        transform.position.z);
    }

    [SerializeField]
    private float xMovementRange, yMovementRange; // Camera movement boundaries
    [SerializeField]
    private Transform player;
}