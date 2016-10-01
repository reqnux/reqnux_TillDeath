using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DifficultyLevelDisplayButton : MonoBehaviour {

	[SerializeField] bool missionMode;

	void OnEnable () {
		if(missionMode)
			GetComponentInChildren<Text> ().text = "Difficulty: "+ GlobalSettings.missionDifficulty.ToString ();
		else
			GetComponentInChildren<Text> ().text = "Difficulty: "+ GlobalSettings.survivalDifficulty.ToString ();
	}
	
}

