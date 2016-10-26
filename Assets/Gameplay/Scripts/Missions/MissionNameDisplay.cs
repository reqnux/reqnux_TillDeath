using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class MissionNameDisplay : MonoBehaviour {

	void Awake () {
		int missionNumber = Formatter.sceneNameToMissionNumber (SceneManager.GetActiveScene ().name);
		GetComponent<Text> ().text = MissionsNames.names [missionNumber - 1];
	}
	
}
