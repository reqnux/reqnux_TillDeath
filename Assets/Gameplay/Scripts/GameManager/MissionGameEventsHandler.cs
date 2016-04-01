﻿using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class MissionGameEventsHandler : MonoBehaviour {

    [SerializeField] EndGamePanel endGamePanel;

    void Start () {
        Player.playerDeathEvent += onPlayerDeath;
    }

    void OnDisable()
    {
        Player.playerDeathEvent -= onPlayerDeath;
    }

    public void onMissionComplete()
    {
        GetComponent<GameManager>().gameStop();
        checkForNewHighscore();
        StartCoroutine(showEndGamePanel());
    }

    void onPlayerDeath()
    {
        GetComponent<GameManager>().gameStop();
        StartCoroutine(showEndGamePanel());
    }

    IEnumerator showEndGamePanel()
    {
        yield return new WaitForSeconds(2);
        endGamePanel.gameObject.SetActive(true);
    }

    void checkForNewHighscore()
    {
        MissionsHighscores scores = new MissionsHighscores();
        int missionNumber = Formatter.sceneNameToMissionNumber(SceneManager.GetActiveScene().name);
        if (scores.checkMissionNewTopScore(missionNumber, GetComponent<CurrentGameStats>().Score))
        {
            scores.setMissionTopScore(missionNumber, GetComponent<CurrentGameStats>().Score);
        }
    }


}

