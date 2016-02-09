using UnityEngine;
using System.Collections;

public class SwitchPanelsButton : MonoBehaviour {

	public GameObject turnOffPanel;
	public GameObject turnOnPanel;

	// Use this for initialization
	void Start () {
	
	}

	public void switchPanels() {
		if (turnOnPanel && turnOffPanel) {
			turnOffPanel.SetActive (false);
			turnOnPanel.SetActive (true);
		} else {
			Debug.LogError ("SwitchPanelsButton : TurnOnPanel or TurnOffPanel not initialized!");
		}
	}
}
