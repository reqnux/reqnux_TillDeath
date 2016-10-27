using UnityEngine;
using System.Collections;

public class CurrentGameStats : MonoBehaviour {

    private int enemiesKilled;
    private int score;

    private Clock clock;

    void Start()
    {
        Enemy.enemyDeathEvent += enemyKilled;
        clock = GameObject.FindObjectOfType<Clock>();
    }

    void OnDisable()
    {
        Enemy.enemyDeathEvent -= enemyKilled;
    }

    void enemyKilled(Enemy enemy)
    {
        enemiesKilled++;
        addScore(enemy);
    }
    void addScore(Enemy enemy)
    {
		score += Mathf.RoundToInt(enemy.Stats.MaxHealth);
    }

    public int EnemiesKilled
    {
        get{ return enemiesKilled;}
    }

    public int Score
    {
        get{ return score;}
    }

    public int TimeSurvived
    {
        get
        {
            return Formatter.clockTextToSeconds(clock.getClockText());
        }
    }
}
