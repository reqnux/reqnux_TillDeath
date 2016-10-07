using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

    public delegate void GameStopEvent();
    public static event GameStopEvent gameStopEvent;

	public static bool gamePaused = false;

	static Player player;
    bool game_stopped = false;

	void Awake() {
		player = GameObject.FindObjectOfType<Player> ();
		GameObject.FindObjectOfType<CursorImageController> ().setAimingCursor ();
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

	public void gameStop()
    {
        game_stopped = true;
        gameStopEvent();
    }

    public bool gameStopped()
    {
        return game_stopped;
    }
}
