using UnityEngine;
using System.Collections;

public class MissionsGridPage : MonoBehaviour {

    [SerializeField] MissionGridButton selectedButton;

    void OnEnable()
    {
        setupMissionsButtons();
    }

    void setupMissionsButtons()
    {
        StatsFilesManager sfm = new StatsFilesManager();
        MissionsHsData missionsHighscores = sfm.loadMissionsHighscores();

        for (int i = 0; i < missionsHighscores.scores.Length; i++)
        {
            if(missionsHighscores.scores[i] > 0)
                transform.FindChild("MissionGridButton" + (i + 1)).GetComponent<MissionGridButton>().setUnlocked(true);
        }
    }

    public MissionGridButton SelectedButton
    {
        set
        {
            if (selectedButton != null)
                selectedButton.setSelectedFrameColor(false);
            selectedButton = value;    
        }
    }

}
