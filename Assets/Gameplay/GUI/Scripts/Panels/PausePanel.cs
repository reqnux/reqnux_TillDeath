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
		playerController.enabled = false;
		GameObject.FindObjectOfType<CursorImageController> ().setDefaultCursor ();
    }

    void OnDisable()
    {
        Time.timeScale = 1;
		GameObject.FindObjectOfType<CursorImageController> ().setAimingCursor ();
		playerController.enabled = true;
    }

}
