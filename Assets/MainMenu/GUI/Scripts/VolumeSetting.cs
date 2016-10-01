using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class VolumeSetting : MonoBehaviour {

	public delegate void OnVolumeSet();
	public static event OnVolumeSet onVolumeSetEvent;

	[SerializeField] SoundType soundType;

	void OnEnable() {
		switch (soundType) {
			case SoundType.Master: GetComponent<Slider> ().value = GlobalSettings.masterVolume; break;
			case SoundType.SFX:	GetComponent<Slider> ().value = GlobalSettings.sfxVolume; break;
			case SoundType.GameMusic: GetComponent<Slider> ().value = GlobalSettings.gameMusicVolume; break;
			case SoundType.MenuMusic: GetComponent<Slider> ().value = GlobalSettings.menuMusicVolume; break;
		}
	}

	public void updateVolumeFromSlider () {
		float value = GetComponent<Slider> ().normalizedValue;
		switch (soundType) {
			case SoundType.Master: GlobalSettings.masterVolume = value; break;
			case SoundType.SFX:	GlobalSettings.sfxVolume = value; break;
			case SoundType.GameMusic: GlobalSettings.gameMusicVolume = value; break;
			case SoundType.MenuMusic: GlobalSettings.menuMusicVolume = value; break;
		}
		if (onVolumeSetEvent != null)
			onVolumeSetEvent ();
	}
}
