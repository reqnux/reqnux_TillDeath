using UnityEngine;
using System.Collections;

public class PlayerPanel : MonoBehaviour {

	LevelUpIndicator levelUpIndicator;

	void Awake() {
		levelUpIndicator = GameObject.Find("PlayerHUD").transform.FindChild("LevelUpIndicator").GetComponent<LevelUpIndicator>();
	}

	void OnEnable() {
		if(levelUpIndicator.isActiveAndEnabled)
			levelUpIndicator.setVisible (false);
	}
}
