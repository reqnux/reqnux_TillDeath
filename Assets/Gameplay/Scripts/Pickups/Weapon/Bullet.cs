using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

    protected Weapon weapon;
    protected float bulletLifeTime = 2;

    protected virtual void OnEnable () {
		Invoke ("deactivate", bulletLifeTime);
	}
	
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Enemy")
        {
            col.gameObject.GetComponent<Enemy>().takeDamage(weapon.Player.Stats.Damage);
        }
		deactivate ();
    }

	void OnDisable() {
		CancelInvoke ();
	}

	void deactivate() {
		Debug.Log ("asd");
		gameObject.SetActive (false);
	}

    public Weapon Weapon 
    {
        set { weapon = value;}
    }
}

public enum BulletType
{
	STANDARD,
	PIERCING
}