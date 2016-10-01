using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ChapterButton : MonoBehaviour {

	[SerializeField] GameObject chapterMissionList;
	[SerializeField] int chapterNumber;

	void Start () {
		int lastCompletedMission = getLastCompletedMissionNumber ();
		if (lastCompletedMission >= 1 + (chapterNumber - 1) * 10 &&
		    lastCompletedMission <= chapterNumber * 10)
			onChapterSelect ();
		else
			onChapterDeselect ();
	}
	
	public void onChapterSelect() {
		setSelectedFrameColor (true);
		if(!chapterMissionList.activeInHierarchy)
			chapterMissionList.SetActive (true);
		
		ChapterButton[] chapterButtons = GameObject.FindObjectsOfType<ChapterButton> ();
		foreach (ChapterButton b in chapterButtons)
			if (b.gameObject.name != gameObject.name)
				b.onChapterDeselect ();
	}
	public void onChapterDeselect() {
		setSelectedFrameColor (false);
		if(chapterMissionList.activeInHierarchy)
			chapterMissionList.SetActive (false);
	}

	void setSelectedFrameColor(bool selected) {
		if (selected)
			GetComponent<Image>().color =  ColorPresets.menuRed;
		else
			GetComponent<Image>().color =  ColorPresets.menuDarkGrey;
	}

	int getLastCompletedMissionNumber() {
		StatsFilesManager sfm = new StatsFilesManager();
		MissionsHsData missionsHighscores = sfm.loadMissionsHighscores();

		if (missionsHighscores.scores [missionsHighscores.scores.Length - 1] > 0)
			return missionsHighscores.scores.Length;

		for (int i = 0; i < missionsHighscores.scores.Length; i++) {
			if(missionsHighscores.scores[i] > 0 && missionsHighscores.scores[i+1] == 0)
				return i+1;
		}
		return 1;
	}
}
