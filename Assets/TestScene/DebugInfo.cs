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
		//if (Input.GetKeyDown (KeyCode.KeypadPlus))
		//	GameManager.Player.levelUp ();
	}

	void OnGUI() {
		//GUI.Label (new Rect (150, 5, 150, 50), "MS: " + GameManager.Player.Stats.MovementSpeed);

	}
}
