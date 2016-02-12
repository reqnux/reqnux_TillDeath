using UnityEngine;
using System.Collections;

public class EnemyAttack : MonoBehaviour {

    private UnitStats enemyStats;

	void Start () {
        enemyStats = GetComponent<Enemy>().Stats;
	}
	
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            col.gameObject.GetComponent<Player>().takeDamage(enemyStats.Damage);
        }
    }
}
