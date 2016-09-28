using UnityEngine;
using System.Collections;

public enum BulletType
{
	STANDARD,
	PIERCING,
	GRANDADE
}

public class Bullet : MonoBehaviour {

    protected Weapon weapon;
    protected float bulletLifeTime = 2;

    protected virtual void OnEnable () {
		Invoke ("deactivate", bulletLifeTime);
	}
	
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Enemy")
			hit (col.gameObject.GetComponent<IDamageable> ());
    }

	//called from outside only by KinematicEnemy script
	public virtual void hit(IDamageable objectHit) {
		objectHit.takeDamage(weapon.Player.Stats.Damage);
		deactivate ();
	}

	void OnDisable() {
		CancelInvoke ();
	}

	protected void deactivate() {
		gameObject.SetActive (false);
	}

	public virtual Weapon Weapon 
    {
        set { weapon = value;}
    }
}