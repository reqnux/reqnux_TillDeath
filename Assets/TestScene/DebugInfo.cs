using UnityEngine;
using System.Collections;

public class DebugInfo : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.E))
			GameObject.FindObjectOfType<FinalMissionEndingSequence> ().play ();
	}

	void OnGUI() {
		GUI.Label (new Rect (150, 5, 150, 50), "Difficulty: " + GameManager.difficulty);
		GUI.Label (new Rect (150, 50, 150, 50), "Horizontal res: " + Screen.width);
		GUI.Label (new Rect (150, 70, 150, 50), "Aspect (w/h): " + Camera.main.aspect);
		GUI.Label (new Rect (150, 90, 150, 50), "ortoSize: " + Camera.main.orthographicSize);
		float myWidth = 2f * Camera.main.orthographicSize * Camera.main.aspect;
		GUI.Label (new Rect (150, 110, 150, 50), "myWidth : " + myWidth);
		GUI.Label (new Rect (150, 130, 150, 50), "screenW/myWidth : " + Screen.width/myWidth);
	}
}
