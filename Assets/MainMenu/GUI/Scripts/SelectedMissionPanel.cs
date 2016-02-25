using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SelectedMissionPanel : MonoBehaviour {

    int selectedMissionNumber;

    void Awake()
    {
        loadMissionInfo(1);
    }

    public void loadMissionInfo(int missionNumber)
    {
        MissionsHighscores ms = new MissionsHighscores();
        transform.FindChild("MissionHighScore").GetComponent<Text>().text = ms.getMissionScore(missionNumber).ToString();
        transform.FindChild("MissionTitle").GetComponent<Text>().text = MissionsNames.names[missionNumber - 1];
        selectedMissionNumber = missionNumber;
    }

    public int SelectedMissionNumber
    {
        get{ return selectedMissionNumber;}
    }
}
