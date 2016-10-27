using UnityEngine;
using System.Collections;

public abstract class Unit : MonoBehaviour , IDamageable{
    [SerializeField] protected UnitStats stats;

	protected virtual void Awake() {
		stats.CurrentHealth = stats.MaxHealth;
    }

    public abstract void death();
	public abstract void takeDamage(float damage);

	public void heal(float health)
    {
        stats.CurrentHealth = Mathf.Min(stats.CurrentHealth + health, stats.MaxHealth);
    }

    public bool isAlive()
    {
        return stats.CurrentHealth > 0;
    }

    public UnitStats Stats {get{return stats;}}

}