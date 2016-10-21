using UnityEngine;
using System.Collections;

public class SlaveZombieHole : MonoBehaviour {

	HugeZombieHole masterHole;

	void Awake() {
		masterHole = GameObject.FindObjectOfType<HugeZombieHole> ();
	}

	void OnDisable() {
		masterHole.onZombieHoleDestroyed ();
	}
}
