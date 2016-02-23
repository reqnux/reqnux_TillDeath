using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MissionEndGamePanel : EndGamePanel {

    [SerializeField] Text panelTitle;
    [SerializeField] Text timeText;
    [SerializeField] Text scoreText;
    [SerializeField] Text enemiesKilledText;

    void OnEnable()
    {
        displayStats();
        if (GameObject.FindObjectOfType<Player>().isAlive())
            panelTitle.text = "MISSION COMPLETED";
        else
            panelTitle.text = "MISSION FAILED";
    }

    void displayStats()
    {
        timeText.text = GameObject.FindObjectOfType<Clock>().getClockText();
        scoreText.text = GameObject.FindObjectOfType<CurrentGameStats>().Score.ToString();
        enemiesKilledText.text = GameObject.FindObjectOfType<CurrentGameStats>().EnemiesKilled.ToString();
    }
}
