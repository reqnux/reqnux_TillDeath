using UnityEngine;
using System.Collections;

public class DebugInfo : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.P))
			GameObject.FindObjectOfType<FinalMissionEndingSequence> ().play ();
	}

	void OnGUI() {
		//GUI.Label (new Rect (150, 5, 150, 50), "Difficulty: " + GameManager.difficulty);

	}
}
