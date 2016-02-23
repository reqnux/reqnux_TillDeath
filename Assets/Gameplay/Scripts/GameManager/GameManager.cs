using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

    public delegate void GameStopEvent();
    public static event GameStopEvent gameStopEvent;

	void Start () {
	
	}
	
	void Update () {
	
	}

    public void gameStop()
    {
        gameStopEvent();
    }
}
