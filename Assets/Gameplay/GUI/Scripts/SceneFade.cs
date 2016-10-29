using UnityEngine;
using System.Collections;

public class SceneFade : MonoBehaviour {

	public delegate void BlackScreenFadeCompletedEvent();
	public static event BlackScreenFadeCompletedEvent blackScreenFadeCompletedEvent;

	public void deathFade() {
		GetComponent<Animator> ().Play ("PlayerDeathFade");
	}

	public void toBlackScreenFade() {
		GetComponent<Animator> ().Play ("BlackScreenFade");
		//Invoke ("blackScreenFadeCompleted", GetComponent<Animator> ().GetCurrentAnimatorStateInfo (0).length);
		Invoke ("blackScreenFadeCompleted", 5);
		StartCoroutine (gameplayMusicFade ());

	}

	IEnumerator gameplayMusicFade() {
		AudioSource audioSource = GameObject.FindObjectOfType<GameManager>().GetComponent<AudioSource>();
		float volumeStep = audioSource.volume / 10f;
		while (audioSource.volume > 0) {
			audioSource.volume -= volumeStep;
			yield return new WaitForSeconds (0.5f);
		}
	}

	void blackScreenFadeCompleted() {
		if (blackScreenFadeCompletedEvent != null)
			blackScreenFadeCompletedEvent ();
	}

}
