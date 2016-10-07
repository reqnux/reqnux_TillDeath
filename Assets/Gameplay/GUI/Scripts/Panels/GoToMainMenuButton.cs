using UnityEngine;
using System.Collections;

public class GoToMainMenuButton : LoadSceneButton {

	public void goToMainMenu() {
		if (!GameManager.gamePaused)
			GameManager.pauseGame ();
		GameManager.stopGame ();
		loadScene ("MainMenu");
	}
}
