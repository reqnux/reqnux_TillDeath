﻿using UnityEngine;
using UnityEngine.UI;
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

            transform.parent.GetComponent<MissionsGridPage>().SelectedButton = this;
            setSelectedFrameColor(true);
        }
    }

    public void setUnlocked(bool value)
    {
        unlocked = true;
        transform.FindChild("lockImage").gameObject.SetActive(!value);
        transform.FindChild("Text").gameObject.GetComponent<Text>().enabled = value;
    }

    public void setSelectedFrameColor(bool selected)
    {
        if (selected)
            GetComponent<Image>().color = new Color(1, 0, 0, 0.58f); //red color preset
        else
            GetComponent<Image>().color = new Color(0.2f, 0.2f, 0.2f, 1.0f); // dark grey color preset
    }

}
