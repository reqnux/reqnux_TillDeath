using UnityEngine;
using System.Collections;

public class CurrentGameStats : MonoBehaviour {

    private int enemiesKilled;

    void Start()
    {
        Enemy.enemyDeathEvent += enemyKilled;
    }

    void OnDisable()
    {
        Enemy.enemyDeathEvent -= enemyKilled;
    }

    void enemyKilled(Enemy enemy)
    {
        enemiesKilled++;
    }


    public int EnemiesKilled
    {
        get{ return enemiesKilled;}
    }

}
