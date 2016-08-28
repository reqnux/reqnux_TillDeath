using UnityEngine;
using System.Collections;

public class TimeControl : MonoBehaviour {

	[SerializeField] float scaleChange = 0.25f;
	bool showTimeScale;


	void Update () {
		if (Input.GetKeyDown (KeyCode.KeypadPlus)) {
			Time.timeScale += scaleChange;
		}
		
		if (Input.GetKeyDown (KeyCode.KeypadMinus)) {
			Time.timeScale = Mathf.Max (0f, Time.timeScale - scaleChange);
		}
		if (Input.GetKeyDown (KeyCode.BackQuote)) { //tylda
			showTimeScale = !showTimeScale;
		}
	}

	void OnGUI() {
		if (showTimeScale) {
			GUI.Label (new Rect (20, 100, 80, 30), Time.timeScale.ToString ());
		}
	}

}
