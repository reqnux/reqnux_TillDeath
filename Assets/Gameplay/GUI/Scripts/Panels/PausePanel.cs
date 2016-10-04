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
    }

    void OnDisable()
    {
        Time.timeScale = 1;
		playerController.enabled = true;
    }

}
