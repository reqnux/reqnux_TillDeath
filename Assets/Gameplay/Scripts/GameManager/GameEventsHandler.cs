﻿using UnityEngine;
using System.Collections;

public class GameEventsHandler : MonoBehaviour {

    [SerializeField]  EndGamePanel endGamePanel;

    void Start () {
        Player.playerDeathEvent += onPlayerDeath;
    }

    void OnDisable()
    {
        Player.playerDeathEvent -= onPlayerDeath;
    }

    void onPlayerDeath()
    {
        //Time.timeScale = 0;
        checkForNewHighscore();
        StartCoroutine(showEndGamePanel());
    }

    IEnumerator showEndGamePanel()
    {
        yield return new WaitForSeconds(2);
        endGamePanel.gameObject.SetActive(true);
    }

    void checkForNewHighscore()
    {
        SurvivalHighscores scores = new SurvivalHighscores();
        if (scores.checkQualifiedOnList(GetComponent<CurrentGameStats>().Score, GetComponent<CurrentGameStats>().TimeSurvived))
        {
            scores.addNewHighscore(GetComponent<CurrentGameStats>().Score, GetComponent<CurrentGameStats>().TimeSurvived);
        }
    }
}
