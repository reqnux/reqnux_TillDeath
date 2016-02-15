using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

    protected Weapon weapon;
    protected float bulletLifeTime = 2;

    protected virtual void Start () {
        Destroy(gameObject, bulletLifeTime);
	}
	
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Enemy")
        {
            col.gameObject.GetComponent<Enemy>().takeDamage(weapon.Player.Stats.Damage);
        }
        Destroy(gameObject);
    }

    public Weapon Weapon 
    {
        set { weapon = value;}
    }
}
