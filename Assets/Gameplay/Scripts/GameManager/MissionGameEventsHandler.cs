using UnityEngine;
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
        //checkForNewHighscore();
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
        SurvivalHighscores scores = new SurvivalHighscores();
        if (scores.checkQualifiedOnList(GetComponent<CurrentGameStats>().Score, GetComponent<CurrentGameStats>().TimeSurvived))
        {
            scores.addNewHighscore(GetComponent<CurrentGameStats>().Score, GetComponent<CurrentGameStats>().TimeSurvived);
        }
    }
}

