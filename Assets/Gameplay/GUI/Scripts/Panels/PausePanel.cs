using UnityEngine;
using System.Collections;

public class PausePanel : MonoBehaviour {
	
	PlayerController playerController;

	void Awake() {
		playerController = GameManager.Player.GetComponent<PlayerController> ();
	}

    void OnEnable()
    {
        Time.timeScale = 0;
		GameManager.gamePaused = true;
		playerController.enabled = false;
		GameObject.FindObjectOfType<CursorImageController> ().setDefaultCursor ();
    }

    void OnDisable()
    {
        Time.timeScale = 1;
		GameManager.gamePaused = false;
		GameObject.FindObjectOfType<CursorImageController> ().setAimingCursor ();
		playerController.enabled = true;
    }

}
