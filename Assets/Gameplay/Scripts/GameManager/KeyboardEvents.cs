using UnityEngine;
using System.Collections;

public class KeyboardEvents : MonoBehaviour {

    public GameObject pausePanel;

    void Update () {
        if (Input.GetKeyDown(KeyCode.Escape) &&
            !GameObject.FindGameObjectWithTag("GameManager").GetComponent<MissionWinConditions>().missionCompleted())
            pausePanel.SetActive(!pausePanel.activeInHierarchy);
    }
}
