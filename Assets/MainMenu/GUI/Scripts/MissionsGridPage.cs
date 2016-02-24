using UnityEngine;
using System.Collections;

public class MissionsGridPage : MonoBehaviour {

    void OnEnable()
    {
        setupMissionsButtons();
    }

    void setupMissionsButtons()
    {
        StatsFilesManager sfm = new StatsFilesManager();
        MissionsHsData missionsHighscores = sfm.loadMissionsHighscores();

        for (int i = 0; i < missionsHighscores.scores.Count; i++)
        {
            transform.FindChild("MissionGridButton" + (i + 1)).GetComponent<MissionGridButton>().setUnlocked(true);
        }
    }

}
