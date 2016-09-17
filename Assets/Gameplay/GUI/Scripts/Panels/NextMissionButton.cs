using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class NextMissionButton : LoadSceneButton {

	public void loadNextMission() {
		int missionNumber = Formatter.sceneNameToMissionNumber (SceneManager.GetActiveScene ().name) + 1;
		loadScene ("Mission" + missionNumber);
	}
}
