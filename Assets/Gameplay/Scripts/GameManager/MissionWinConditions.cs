using UnityEngine;
using System.Collections;

public class MissionWinConditions : MonoBehaviour {

    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (missoinCompleted())
        {
            GetComponent<MissionGameEventsHandler>().onMissionComplete();
        }
	}


    bool missoinCompleted()
    {
        return GameObject.FindGameObjectsWithTag("Spawner").Length == 0
            && GameObject.FindGameObjectsWithTag("Enemy").Length == 0;
    }

}
