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
        Debug.Log("enejbel;");
        displayStats();
        if (GameObject.FindObjectOfType<Player>().isAlive())
        {
            panelTitle.text = "MISSION COMPLETED";
            transform.FindChild("ReplayMissionButton").gameObject.SetActive(false);
        }
        else
        {
            Debug.Log("enejbel false");
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
