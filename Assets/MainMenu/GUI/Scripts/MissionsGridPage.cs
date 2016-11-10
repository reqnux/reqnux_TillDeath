using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MissionsGridPage : MonoBehaviour {

    [SerializeField] MissionGridButton selectedButton;
	[SerializeField] int chapterNumber;

	static MissionGridButton globalSelectecButton;

    void OnEnable()
    {
        setupMissionsButtons();
		transform.parent.GetComponent<ScrollRect> ().content = (RectTransform)transform;;

		if(globalSelectecButton != null && selectedButton != null && globalSelectecButton != selectedButton)
			selectedButton.setSelectedFrameColor(false);
    }

    void setupMissionsButtons()
    {
        StatsFilesManager sfm = new StatsFilesManager();
        MissionsHsData missionsHighscores = sfm.loadMissionsHighscores();
		int startIndex = (chapterNumber - 1) * 10;
		for (int i = startIndex; i < startIndex + 10; i++)
        {
			if (missionsHighscores.scores [i] > 0 || (i >= 1 && missionsHighscores.scores [i - 1] > 0))
				transform.FindChild ("MissionGridButton" + (i + 1)).GetComponent<MissionGridButton> ().setUnlocked (true);
        }
    }

    public MissionGridButton SelectedButton
    {
        set
        {
            if (selectedButton != null)
                selectedButton.setSelectedFrameColor(false);
            selectedButton = value;
			globalSelectecButton = selectedButton;
        }
    }

}
