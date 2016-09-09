using UnityEngine;
using System.Collections;

public class KeyboardEvents : MonoBehaviour {

    public GameObject playerPanel;
	public GameObject pausePanel;

    void Update () {
		if (Input.GetKeyDown(KeyCode.Tab))
			playerPanel.SetActive(!playerPanel.activeInHierarchy);
        if (Input.GetKeyDown(KeyCode.Escape))
            pausePanel.SetActive(!pausePanel.activeInHierarchy);
    }
}
