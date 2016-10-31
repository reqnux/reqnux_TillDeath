using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour {

    public float xMovementRange, yMovementRange = 0; // Camera movement boundaries
	[SerializeField] Transform player = null;

    void Update()
    {
        transform.position = new Vector3(Mathf.Clamp(player.position.x,-xMovementRange,xMovementRange),
                                        Mathf.Clamp(player.position.y,-yMovementRange,yMovementRange),
                                        transform.position.z);
    }

	public void adjustRangesToOrtographicSize() {
		yMovementRange = Map.mapSizeY / 2f - Camera.main.orthographicSize;
	}
}
