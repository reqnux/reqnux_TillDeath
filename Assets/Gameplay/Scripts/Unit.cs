using UnityEngine;
using System.Collections;

public abstract class Unit : MonoBehaviour 
{
    [SerializeField]
    protected UnitStats stats;

    public virtual void Awake() 
    {
    }

    public abstract void death();
    public abstract void takeDamage(int damage);

    public UnitStats Stats {get{return stats;}}

}