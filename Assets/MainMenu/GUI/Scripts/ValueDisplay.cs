using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ValueDisplay : MonoBehaviour {

	Text text;

	void Awake() {
		text = GetComponent<Text> ();
	}

	public void displayValue(int value) {
		text.text = ((int)value).ToString ();
	}
	public void displayValue(Slider slider) {
		text.text = ((int)slider.value).ToString ();
	}
}
