using UnityEngine;
using System.Collections;

public class SlaveZombieHole : MonoBehaviour {

	HugeZombieHole masterHole;

	void Awake() {
		masterHole = GameObject.FindObjectOfType<HugeZombieHole> ();
	}

	void OnDisable() {
		if(masterHole != null && masterHole.gameObject != null)
			masterHole.onZombieHoleDestroyed ();
	}
}
