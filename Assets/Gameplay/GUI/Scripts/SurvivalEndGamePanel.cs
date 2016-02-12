using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SurvivalEndGamePanel : EndGamePanel {

    [SerializeField] Text timeSurvivedText;
    [SerializeField] Text enemiesKilledText;


	// Use this for initialization
	void Start () {
	
	}
	
    void OnEnable()
    {
        displayStats();
    }

    void displayStats()
    {
        timeSurvivedText.text = GameObject.FindObjectOfType<Clock>().getClockText();
        enemiesKilledText.text = GameObject.FindObjectOfType<CurrentGameStats>().EnemiesKilled.ToString();
    }
}
