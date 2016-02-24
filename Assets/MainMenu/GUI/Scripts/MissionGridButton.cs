using UnityEngine;
using System.Collections;

public class MissionGridButton : MonoBehaviour {

    [SerializeField] bool unlocked;
    SelectedMissionPanel selectedMissionPanel;

	void Start () {
        selectedMissionPanel = GameObject.FindObjectOfType<SelectedMissionPanel>();
	}

    public void onMissionSelect()
    {
        if (unlocked)
        {
            int missionNumber = int.Parse(gameObject.name.Substring(17,gameObject.name.Length-17));
            selectedMissionPanel.loadMissionInfo(missionNumber);
        }
    }

    public void setUnlocked(bool value)
    {
        transform.FindChild("lockImage").gameObject.SetActive(!value);
        transform.FindChild("Text").gameObject.SetActive(value);
    }

}
