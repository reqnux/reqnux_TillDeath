using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour {

    [SerializeField]
    private float xMovementRange, yMovementRange = 0; // Camera movement boundaries
    [SerializeField]
    private Transform player = null;

    void Update()
    {
        transform.position = new Vector3(Mathf.Clamp(player.position.x,-xMovementRange,xMovementRange),
                                        Mathf.Clamp(player.position.y,-yMovementRange,yMovementRange),
                                        transform.position.z);
    }
}
