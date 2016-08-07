using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SurvivalEndGamePanel : EndGamePanel {

	[SerializeField] Text timeSurvivedText = null;
    [SerializeField] Text scoreText = null;
	[SerializeField] Text enemiesKilledText = null;

    void OnEnable()
    {
        displayStats();
    }

    void displayStats()
    {
        timeSurvivedText.text = GameObject.FindObjectOfType<Clock>().getClockText();
        scoreText.text = GameObject.FindObjectOfType<CurrentGameStats>().Score.ToString();
        enemiesKilledText.text = GameObject.FindObjectOfType<CurrentGameStats>().EnemiesKilled.ToString();
    }
}
