using UnityEngine;
using System.Collections;

public enum SoundType {Master, SFX, GameMusic, MenuMusic}

[RequireComponent (typeof (AudioSource))]
public class VolumeControl : MonoBehaviour {

	[SerializeField] SoundType soundType;
	AudioSource audioSource;

	void Awake() {
		audioSource = GetComponent<AudioSource> ();
	}

	void OnEnable () {
		VolumeSetting.onVolumeSetEvent += updateVolume;
		updateVolume ();
	}

	public void updateVolume() {
		switch (soundType) {
			case SoundType.SFX:	audioSource.volume = GlobalSettings.sfxVolume * GlobalSettings.masterVolume; break;
			case SoundType.GameMusic: audioSource.volume = GlobalSettings.gameMusicVolume * GlobalSettings.masterVolume; break;
			case SoundType.MenuMusic: audioSource.volume = GlobalSettings.menuMusicVolume * GlobalSettings.masterVolume; break;
		}
	}

	void OnDisable () {
		VolumeSetting.onVolumeSetEvent -= updateVolume;
	}
}
