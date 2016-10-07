using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BloodSetting : MonoBehaviour {

	Toggle toggle;

	void Awake() {
		toggle = GetComponent<Toggle> ();
	}

	void OnEnable() {
		if (gameObject.name == "BloodOnGround")
			toggle.isOn = GlobalSettings.bloodOnGround;
		else if (gameObject.name == "BloodSplash")
			toggle.isOn = GlobalSettings.bloodSplash;
	}

	public void onToggleChange() {
		if (gameObject.name == "BloodOnGround") {
			GlobalSettings.bloodOnGround = toggle.isOn;
			PlayerPrefs.SetInt ("bloodOnGround", Formatter.boolToInt (toggle.isOn));
		} else if (gameObject.name == "BloodSplash") {
			GlobalSettings.bloodSplash = toggle.isOn;
			PlayerPrefs.SetInt ("bloodSplash", Formatter.boolToInt (toggle.isOn));
		}
	}

}
