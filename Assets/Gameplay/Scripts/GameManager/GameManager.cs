using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameManager : MonoBehaviour {

    public delegate void GameStopEvent();
    public static event GameStopEvent gameStopEvent;

	public static bool gameStopped = false;
	public static bool gamePaused = false;
	public static Difficulty difficulty;

	static Player player;
	static CursorImageController cursorImageController;

	void Awake() {
		Time.timeScale = 1;
		gamePaused = false;
		gameStopped = false;
		player = GameObject.FindObjectOfType<Player> ();
		setDifficulty ();
		cursorImageController = GameObject.FindObjectOfType<CursorImageController> ();
		cursorImageController.setAimingCursor ();
	}

	public static Player Player {
		get {
			if (player == null) {
				player = GameObject.FindObjectOfType<Player> ();
				if (player == null)
					Debug.LogError ("Cant find Player object in the scene!");
			}
			return player;
		}
	}

	public static void pauseGame() {
		Time.timeScale = 0;
		gamePaused = true;
		player.GetComponent<PlayerController>().enabled = false;
		cursorImageController.setDefaultCursor ();
	}

	public static void unpauseGame() {
		if (!gameStopped) {
			Time.timeScale = 1;
			gamePaused = false;
			cursorImageController.setAimingCursor ();
			player.GetComponent<PlayerController> ().enabled = true;
		}
	}

	public static void stopGame() {
        gameStopped = true;
		if(gameStopEvent != null)
        	gameStopEvent();
    }

	void setDifficulty() {
		if(SceneManager.GetActiveScene().name == "Survival")
			difficulty = GlobalSettings.survivalDifficulty;
		else
			difficulty = GlobalSettings.missionDifficulty;
	}
}
