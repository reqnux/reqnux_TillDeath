using UnityEngine;
using System.Collections;

public abstract class Unit : MonoBehaviour 
{
    protected UnitStats stats;

    public virtual void Start() 
    {
        stats = new UnitStats();
    }

    public abstract void death();
    public abstract void takeDamage(int damage);

    public UnitStats Stats {get{return stats;}}

}