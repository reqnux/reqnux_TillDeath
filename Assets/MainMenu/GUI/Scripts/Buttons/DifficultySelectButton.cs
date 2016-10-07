using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DifficultySelectButton : MonoBehaviour {

	[SerializeField] bool missionMode;
	[SerializeField] Difficulty difficulty;

	void OnEnable() {
		if (missionMode) {
			if (GlobalSettings.missionDifficulty == difficulty)
				onSelect ();
		}
		else if (GlobalSettings.survivalDifficulty == difficulty)
			onSelect ();
	}

	public void onSelect() {
		if (missionMode) {
			GlobalSettings.missionDifficulty = difficulty;
			PlayerPrefs.SetInt ("missionDifficulty", (int)difficulty);
		} else {
			GlobalSettings.survivalDifficulty = difficulty;
			PlayerPrefs.SetInt ("survivalDifficulty", (int)difficulty);
		}
		transform.FindChild ("TitlePanel").GetComponent<Image> ().color = ColorPresets.menuRed;
		deselectOtherButtons ();
	}

	public void onDeselect() {
		transform.FindChild ("TitlePanel").GetComponent<Image> ().color = ColorPresets.menuDarkGrey;
	}

	void deselectOtherButtons()	{
		DifficultySelectButton[] buttons = transform.parent.GetComponentsInChildren<DifficultySelectButton> ();
		foreach (DifficultySelectButton b in buttons)
			if (b.gameObject.name != gameObject.name)
				b.onDeselect ();
	}


}
