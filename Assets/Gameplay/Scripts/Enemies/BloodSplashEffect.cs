﻿using UnityEngine;
using System.Collections;

public class BloodSplashEffect : MonoBehaviour {

	AudioSource audioSource;

	void Awake () {
		audioSource = GetComponent<AudioSource> ();
	}
	
	void OnEnable () {
		audioSource.PlayOneShot (audioSource.clip);
		Invoke ("disable", audioSource.clip.length);
	}

	void disable() {
		gameObject.SetActive (false);
	}
}
