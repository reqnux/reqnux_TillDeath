using UnityEngine;
using System.Collections;

public class MissionWinConditions : MonoBehaviour {

    GameManager gameManager;
	MissionScenario scenario;

    void Start () {
        gameManager = GetComponent<GameManager>();
		scenario = GameObject.FindObjectOfType<MissionScenario> ();
	}
	
	void Update () {
        if (!gameManager.gameStopped() && missionCompleted())
        {
            GetComponent<MissionGameEventsHandler>().onMissionComplete();
        }
	}

    public bool missionCompleted()
    {
		return scenario.ended() && GameObject.FindGameObjectsWithTag("Enemy").Length == 0;
    }

}
