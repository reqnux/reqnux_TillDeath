using UnityEngine;
using System.Collections;

public enum SoundType {Master, SFX, GameMusic, MenuMusic}

[RequireComponent (typeof (AudioSource))]
public class VolumeControl : MonoBehaviour {

	[SerializeField] SoundType soundType;
	AudioSource[] audioSources;

	void Awake() {
		audioSources = GetComponents<AudioSource> ();
	}

	void OnEnable () {
		VolumeSetting.onVolumeSetEvent += updateVolume;
		updateVolume ();
	}

	public void updateVolume() {
		switch (soundType) {
			case SoundType.SFX:	setVolume(GlobalSettings.sfxVolume * GlobalSettings.masterVolume); break;
			case SoundType.GameMusic: setVolume(GlobalSettings.gameMusicVolume * GlobalSettings.masterVolume); break;
			case SoundType.MenuMusic: setVolume(GlobalSettings.menuMusicVolume * GlobalSettings.masterVolume); break;
		}
	}
	void setVolume(float value) {
		foreach(AudioSource audio in audioSources)
			audio.volume = value;
	}

	void OnDisable () {
		VolumeSetting.onVolumeSetEvent -= updateVolume;
	}
}
