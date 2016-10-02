using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class VolumeSetting : MonoBehaviour {

	public delegate void OnVolumeSet();
	public static event OnVolumeSet onVolumeSetEvent;

	[SerializeField] SoundType soundType;

	void OnEnable() {
		switch (soundType) {
			case SoundType.Master: GetComponent<Slider> ().value = GlobalSettings.masterVolume*100; break;
			case SoundType.SFX:	GetComponent<Slider> ().value = GlobalSettings.sfxVolume*100; break;
			case SoundType.GameMusic: GetComponent<Slider> ().value = GlobalSettings.gameMusicVolume*100; break;
			case SoundType.MenuMusic: GetComponent<Slider> ().value = GlobalSettings.menuMusicVolume*100; break;
		}
	}

	public void updateVolumeFromSlider () {
		float value = GetComponent<Slider> ().normalizedValue;
		switch (soundType) {
			case SoundType.Master: GlobalSettings.masterVolume = value; PlayerPrefs.SetFloat ("masterVolume", value); break;
			case SoundType.SFX:	GlobalSettings.sfxVolume = value; PlayerPrefs.SetFloat ("sfxVolume", value); break;
			case SoundType.GameMusic: GlobalSettings.gameMusicVolume = value; PlayerPrefs.SetFloat ("gameMusicVolume", value); break;
			case SoundType.MenuMusic: GlobalSettings.menuMusicVolume = value; PlayerPrefs.SetFloat ("menuMusicVolume", value); break;
		}
		if (onVolumeSetEvent != null)
			onVolumeSetEvent ();
	}
}
