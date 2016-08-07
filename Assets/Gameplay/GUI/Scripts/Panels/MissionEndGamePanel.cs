using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MissionEndGamePanel : EndGamePanel {

    [SerializeField] Text panelTitle = null;
    [SerializeField] Text timeText = null;
    [SerializeField] Text scoreText = null;
    [SerializeField] Text enemiesKilledText = null;

    void OnEnable()
    {
        displayStats();
        if (GameObject.FindObjectOfType<Player>().isAlive())
        {
            panelTitle.text = "MISSION COMPLETED";
            transform.FindChild("ReplayMissionButton").gameObject.SetActive(false);
        }
        else
        {
            panelTitle.text = "MISSION FAILED";
            transform.FindChild("NextMissionButton").gameObject.SetActive(false);
        }
    }

    void displayStats()
    {
        timeText.text = GameObject.FindObjectOfType<Clock>().getClockText();
        scoreText.text = GameObject.FindObjectOfType<CurrentGameStats>().Score.ToString();
        enemiesKilledText.text = GameObject.FindObjectOfType<CurrentGameStats>().EnemiesKilled.ToString();
    }
}
