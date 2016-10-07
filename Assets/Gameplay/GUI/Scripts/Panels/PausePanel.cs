using UnityEngine;
using System.Collections;

public class PausePanel : MonoBehaviour {
	
	PlayerController playerController;
	CursorImageController cursorImageController;

	void Awake() {
		playerController = GameManager.Player.GetComponent<PlayerController> ();
		cursorImageController = GameObject.FindObjectOfType<CursorImageController> ();
	}

    void OnEnable()
    {
        Time.timeScale = 0;
		GameManager.gamePaused = true;
		playerController.enabled = false;
		cursorImageController.setDefaultCursor ();
    }

    void OnDisable()
    {
		Time.timeScale = 1;
		if (!GameManager.gameStopped) {
			GameManager.gamePaused = false;
			cursorImageController.setAimingCursor ();
			playerController.enabled = true;
		}
    }

}
