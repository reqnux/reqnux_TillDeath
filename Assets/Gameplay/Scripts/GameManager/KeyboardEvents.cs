using UnityEngine;
using System.Collections;

public class KeyboardEvents : MonoBehaviour {

    GameObject playerPanel;
	GameObject pausePanel;

	void Awake() {
		playerPanel = GameObject.Find ("BasePanel").transform.FindChild ("PlayerPanel").gameObject;
		pausePanel = GameObject.Find ("BasePanel").transform.FindChild ("PausePanel").gameObject;
	}

    void Update () {
		if (Input.GetKeyDown (KeyCode.Tab)) {
			if(!GameManager.gamePaused || GameManager.gamePaused && playerPanel.activeInHierarchy)
				playerPanel.SetActive(!playerPanel.activeInHierarchy);
		}
		if (Input.GetKeyDown (KeyCode.Escape)) {
			if (playerPanel.activeInHierarchy) {
				playerPanel.SetActive (false);
			}
			pausePanel.SetActive(!pausePanel.activeInHierarchy);
		}
    }
}
