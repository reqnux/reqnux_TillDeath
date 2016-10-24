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
		Invoke ("blackScreenFadeCompleted", GetComponent<Animator> ().GetCurrentAnimatorStateInfo (0).length);

	}

	void blackScreenFadeCompleted() {
		if (blackScreenFadeCompletedEvent != null)
			blackScreenFadeCompletedEvent ();
	}

}
