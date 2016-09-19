using UnityEngine;
using System.Collections;

public abstract class Unit : MonoBehaviour , IDamageable{
    [SerializeField] protected UnitStats stats;

	protected virtual void Awake() {
		stats.CurrentHealth = stats.MaxHealth;
    }

    public abstract void death();
    public abstract void takeDamage(int damage);

    public void heal(int health)
    {
        stats.CurrentHealth = Mathf.Min(stats.CurrentHealth + health, stats.MaxHealth);
    }

    public bool isAlive()
    {
        return stats.CurrentHealth > 0;
    }

    public UnitStats Stats {get{return stats;}}

}