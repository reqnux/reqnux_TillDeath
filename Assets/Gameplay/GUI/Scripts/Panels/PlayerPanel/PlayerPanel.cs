using UnityEngine;
using System.Collections;

public class PlayerPanel : MonoBehaviour {

	[SerializeField] LevelUpIndicator levelUpIndicator;

	void OnEnable() {
		levelUpIndicator.setVisible (false);
	}
}
