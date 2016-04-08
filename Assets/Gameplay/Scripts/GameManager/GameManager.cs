using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

    public delegate void GameStopEvent();
    public static event GameStopEvent gameStopEvent;

    bool game_stopped = false;

	void Start () {
	
	}
	
	void Update () {
	
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
