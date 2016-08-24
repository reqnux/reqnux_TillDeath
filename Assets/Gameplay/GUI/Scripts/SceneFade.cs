using UnityEngine;
using System.Collections;

public class SceneFade : MonoBehaviour {

	void OnEnable () {
		Player.playerDeathEvent += deathFade;
	}
	
	void deathFade() {
		GetComponent<Animator> ().Play ("PlayerDeathFade");
	}

	void OnDisable () {
		Player.playerDeathEvent -= deathFade;
	}
}
