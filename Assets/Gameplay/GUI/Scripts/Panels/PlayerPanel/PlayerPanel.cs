using UnityEngine;
using System.Collections;

public class PlayerPanel : MonoBehaviour {

	LevelUpIndicator levelUpIndicator;

	void Awake() {
		levelUpIndicator = GameObject.FindObjectOfType<LevelUpIndicator>();
	}

	void OnEnable() {
		levelUpIndicator.setVisible (false);
	}
}
