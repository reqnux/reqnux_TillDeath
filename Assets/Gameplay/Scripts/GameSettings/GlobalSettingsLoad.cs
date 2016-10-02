using UnityEngine;
using System.Collections;

public class GlobalSettingsLoad : MonoBehaviour {

	void Awake() {
		//sound
		GlobalSettings.masterVolume = PlayerPrefs.GetFloat("masterVolume",0.75f);
		GlobalSettings.sfxVolume = PlayerPrefs.GetFloat("sfxVolume",0.75f);
		GlobalSettings.gameMusicVolume = PlayerPrefs.GetFloat("gameMusicVolume",0.75f);
		GlobalSettings.menuMusicVolume = PlayerPrefs.GetFloat("menuMusicVolume",0.75f);
	}
}
