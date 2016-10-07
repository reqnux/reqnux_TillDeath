using UnityEngine;
using System.Collections;

public class PausePanel : MonoBehaviour {
	
    void OnEnable()
    {
		if(!GameManager.gamePaused)
			GameManager.pauseGame ();
    }

    void OnDisable()
    {
		if (GameManager.gamePaused)
			GameManager.unpauseGame ();
    }

}
