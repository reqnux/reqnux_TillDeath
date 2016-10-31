using UnityEngine;
using System.Collections;

public class CameraSizeScaling : MonoBehaviour {

	void Awake() {
		GetComponent<Camera> ().orthographicSize = Map.mapSizeX / (2f*GetComponent<Camera> ().aspect);
		GetComponent<CameraMovement> ().adjustRangesToOrtographicSize ();
	}
}
