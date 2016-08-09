using UnityEngine;
using System.Collections.Generic;

public class PiercingBullet : Bullet {

    private List<Enemy> hitEnemies;

	void Awake() {
		hitEnemies = new List<Enemy>();
	}

    protected override void OnEnable() {
		base.OnEnable();
		hitEnemies.Clear ();
    }

    void OnTriggerEnter2D(Collider2D col) {
        if(col.gameObject.tag == "Enemy") {
           /* if(!hitEnemies.Contains(col.gameObject.GetComponent<Enemy>())) {
                hitEnemies.Add(col.gameObject.GetComponent<Enemy>());
            }
            foreach(Enemy e in hitEnemies) {
                e.takeDamage(weapon.Player.Stats.Damage);
            }
            */
            col.gameObject.GetComponent<Enemy>().takeDamage(weapon.Player.Stats.Damage);

        }
    }
}
