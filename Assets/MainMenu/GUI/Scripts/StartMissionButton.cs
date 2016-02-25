using UnityEngine;
using System.Collections;

public class StartMissionButton : LoadSceneButton {

    public void startMission()
    {
        loadScene("Mission" + GameObject.FindObjectOfType<SelectedMissionPanel>().SelectedMissionNumber);
    }
}
