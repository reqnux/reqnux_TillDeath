﻿using UnityEngine;
using System.Collections;

public class GlobalSettingsLoad : MonoBehaviour {

	void Awake() {
		GlobalSettings.missionDifficulty = (Difficulty)PlayerPrefs.GetInt("missionDifficulty", (int)Difficulty.Normal);
		GlobalSettings.survivalDifficulty = (Difficulty)PlayerPrefs.GetInt("survivalDifficulty", (int)Difficulty.Normal);

		GlobalSettings.bloodOnGround = Formatter.intToBool (PlayerPrefs.GetInt ("bloodOnGround",1));
		GlobalSettings.bloodSplash = Formatter.intToBool (PlayerPrefs.GetInt ("bloodSplash",1));

		GlobalSettings.masterVolume = PlayerPrefs.GetFloat("masterVolume",0.75f);
		GlobalSettings.sfxVolume = PlayerPrefs.GetFloat("sfxVolume",0.75f);
		GlobalSettings.gameMusicVolume = PlayerPrefs.GetFloat("gameMusicVolume",0.75f);
		GlobalSettings.menuMusicVolume = PlayerPrefs.GetFloat("menuMusicVolume",0.75f);
	}
}
