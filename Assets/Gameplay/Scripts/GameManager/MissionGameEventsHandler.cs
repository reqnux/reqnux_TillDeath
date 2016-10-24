using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class MissionGameEventsHandler : MonoBehaviour {

    EndGamePanel endGamePanel;

	void Awake() {
		endGamePanel = GameObject.Find ("BasePanel").transform.FindChild ("MissionEndGamePanel").GetComponent<MissionEndGamePanel> ();
	}

    void Start () {
        Player.playerDeathEvent += onPlayerDeath;
    }

    void OnDisable()
    {
        Player.playerDeathEvent -= onPlayerDeath;
    }

    public void onMissionComplete()
    {
		if (SceneManager.GetActiveScene ().name == "Mission30") {
			checkForNewHighscore();
			GameObject.FindObjectOfType<FinalMissionEndingSequence> ().play ();
		} else {
			GameManager.stopGame();
			checkForNewHighscore();
			StartCoroutine(showEndGamePanel());
		}
    }

    void onPlayerDeath()
    {
		GameManager.stopGame ();
		if (SceneManager.GetActiveScene ().name == "Mission30"
		    && GameObject.FindObjectOfType<FinalMissionEndingSequence> ().SequenceStarted) {
			GameObject.FindObjectOfType<SceneFade> ().toBlackScreenFade ();
		} else {
			GameObject.FindObjectOfType<SceneFade> ().deathFade ();
			StartCoroutine (showEndGamePanel ());
		}
    }

    IEnumerator showEndGamePanel()
    {
        yield return new WaitForSeconds(2);
        endGamePanel.gameObject.SetActive(true);
    }

    void checkForNewHighscore()
    {
        MissionsHighscores scores = new MissionsHighscores();
        int missionNumber = Formatter.sceneNameToMissionNumber(SceneManager.GetActiveScene().name);
        if (scores.checkMissionNewTopScore(missionNumber, GetComponent<CurrentGameStats>().Score))
        {
            scores.setMissionTopScore(missionNumber, GetComponent<CurrentGameStats>().Score);
        }
    }


}

