using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public enum AudioType {
	BulletShot,
	BloodSplash,
	Reload,
	ZombieHoleCollapse,
	ZombieHoleShieldHit
}

public class AudioManager : MonoBehaviour {

	[SerializeField] int bulletShotCap = 15;
	[SerializeField] int bloodSplashCap = 15;
	[SerializeField] int zombieHoleCollapseCap = 3;
	[SerializeField] int zombieHoleShieldHitCap = 5;

	Dictionary<AudioType,int> audiosPlaying;
	Dictionary<AudioType,int> audiosMaxCap;

	void Awake() {
		audiosPlaying = new Dictionary<AudioType,int> () {
			{ AudioType.BulletShot,0},
			{ AudioType.BloodSplash,0},
			{ AudioType.ZombieHoleCollapse,0},
			{ AudioType.ZombieHoleShieldHit,0}
		};
		audiosMaxCap = new Dictionary<AudioType,int> () {
			{ AudioType.BulletShot,bulletShotCap},
			{ AudioType.BloodSplash,bloodSplashCap},
			{ AudioType.ZombieHoleCollapse,zombieHoleCollapseCap},
			{ AudioType.ZombieHoleShieldHit,zombieHoleShieldHitCap}
		};
	}

	public void play(AudioType type, float length) {
		audiosPlaying [type] = audiosPlaying [type] + 1;
		StartCoroutine (decrementAudiosPlaying (type, length));
	}

	public bool canPlay(AudioType type) {
		return audiosPlaying [type] < audiosMaxCap [type];
	}

	IEnumerator decrementAudiosPlaying(AudioType type,float length) {
		yield return new WaitForSeconds (length);
		audiosPlaying [type] = audiosPlaying [type] - 1;
	}

}
