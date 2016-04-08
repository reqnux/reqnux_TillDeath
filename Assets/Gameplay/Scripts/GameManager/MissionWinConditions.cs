using UnityEngine;
using System.Collections;

public class MissionWinConditions : MonoBehaviour {

    GameManager gameManager;

    void Start () {
        gameManager = GetComponent<GameManager>();
	}
	
	// Update is called once per frame
	void Update () {
        if (!gameManager.gameStopped() && missionCompleted())
        {
            GetComponent<MissionGameEventsHandler>().onMissionComplete();
        }
	}


    bool missionCompleted()
    {
        return GameObject.FindGameObjectsWithTag("Spawner").Length == 0
            && GameObject.FindGameObjectsWithTag("Enemy").Length == 0;
    }

}
