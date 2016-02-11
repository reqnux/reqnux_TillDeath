using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

    private Weapon weapon;

    void Start () {
	
	}
	
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Enemy")
        {
            col.gameObject.GetComponent<Enemy>().takeDamage(weapon.Player.Stats.Damage);
            Destroy(gameObject);
        }
    }

    public Weapon Weapon 
    {
        set { weapon = value;}
    }
}
