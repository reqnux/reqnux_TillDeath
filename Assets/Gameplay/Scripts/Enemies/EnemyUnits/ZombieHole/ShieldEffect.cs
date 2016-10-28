using UnityEngine;
using System.Collections;

public class ShieldEffect : MonoBehaviour {

	[SerializeField] float effectDuration = 0.5f;
	GameObject effects;
	SpriteRenderer shieldSprite;
	AudioSource audioSource;

	void Awake () {
		effects = transform.FindChild ("Effects").gameObject;
		shieldSprite = effects.transform.FindChild ("shield").GetComponent<SpriteRenderer>();
		audioSource = GetComponent<AudioSource> ();
	}
	
	public void playEffect() {
		CancelInvoke ();
		effects.SetActive (true);
		shieldSprite.flipY = !shieldSprite.flipY;
		GameManager.AudioManager.play (audioSource, AudioType.ZombieHoleShieldHit);
		Invoke ("stopEffect", effectDuration);
	}

	void stopEffect() {
		effects.SetActive (false);
	}
}
