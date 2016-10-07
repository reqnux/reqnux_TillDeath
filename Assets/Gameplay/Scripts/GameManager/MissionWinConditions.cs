using UnityEngine;
using System.Collections;

public class MissionWinConditions : MonoBehaviour {

	MissionScenario scenario;

    void Start () {
		scenario = GameObject.FindObjectOfType<MissionScenario> ();
	}
	
	void Update () {
        if (!GameManager.gameStopped && missionCompleted())
        {
            GetComponent<MissionGameEventsHandler>().onMissionComplete();
        }
	}

    public bool missionCompleted()
    {
		return scenario.ended() && GameObject.FindGameObjectsWithTag("Enemy").Length == 0;
    }

}
