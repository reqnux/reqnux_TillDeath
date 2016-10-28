using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public enum AudioType {
	BulletShot,
	Explosion,
	BloodSplash,
	ZombieHoleCollapse,
	ZombieHoleShieldHit,
	Other
}

public class AudioManager : MonoBehaviour {

	[SerializeField] int bulletShotCap = 6;
	[SerializeField] int explosionCap = 4;
	[SerializeField] int bloodSplashCap = 20;
	[SerializeField] int zombieHoleCollapseCap = 3;
	[SerializeField] int zombieHoleShieldHitCap = 5;
	[SerializeField] int otherSoundsCap = 5;

	Dictionary<AudioType,int> audiosPlaying;
	Dictionary<AudioType,int> audiosMaxCap;

	void Awake() {
		audiosPlaying = new Dictionary<AudioType,int> () {
			{ AudioType.BulletShot,0},
			{ AudioType.Explosion,0},
			{ AudioType.BloodSplash,0},
			{ AudioType.ZombieHoleCollapse,0},
			{ AudioType.ZombieHoleShieldHit,0},
			{ AudioType.Other,0}
		};
		audiosMaxCap = new Dictionary<AudioType,int> () {
			{ AudioType.BulletShot,bulletShotCap},
			{ AudioType.Explosion,explosionCap},
			{ AudioType.BloodSplash,bloodSplashCap},
			{ AudioType.ZombieHoleCollapse,zombieHoleCollapseCap},
			{ AudioType.ZombieHoleShieldHit,zombieHoleShieldHitCap},
			{ AudioType.Other,otherSoundsCap}
		};
	}

	public void play(AudioSource source, AudioType type) {
		if (canPlay (type)) {
			source.PlayOneShot (source.clip);
			audiosPlaying [type] = audiosPlaying [type] + 1;
			StartCoroutine (decrementAudiosPlaying (type, source.clip.length));
		}
	}

	bool canPlay(AudioType type) {
		return audiosPlaying [type] < audiosMaxCap [type];
	}

	IEnumerator decrementAudiosPlaying(AudioType type,float length) {
		yield return new WaitForSeconds (length);
		audiosPlaying [type] = audiosPlaying [type] - 1;
	}

}
