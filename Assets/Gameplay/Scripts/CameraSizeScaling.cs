using UnityEngine;
using System.Collections;

public class CameraSizeScaling : MonoBehaviour {

	// Testing resolution - 1680:1050 = 16:10
	// Testing ortigraphicSize - 8

	// desiredCameraAspect = Screen.width / 2*ortigraphicSize*Camera.aspect
	const float desiredCameraAspect = 49.375f;

	void Awake() {
		GetComponent<Camera> ().orthographicSize = Screen.width / (2 * desiredCameraAspect * GetComponent<Camera> ().aspect);
		GetComponent<CameraMovement> ().adjustRangesToOrtographicSize ();
	}
}
