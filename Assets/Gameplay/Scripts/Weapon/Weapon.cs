using UnityEngine;
using System.Collections;

public abstract class Weapon : MonoBehaviour {

    [SerializeField] protected int damage;
    protected int currentAmmo;
    [SerializeField] protected int clipSize;
    [SerializeField] protected float reloadTime;
    [SerializeField] protected float delayBetweenShots;

    public virtual void Awake () 
    {
        currentAmmo = clipSize;
    }
    
    void Update () {
    
    }

    public abstract void shoot();

    public void reload()
    {
        currentAmmo = clipSize;
    }

    public int CurrentAmmo
    {
        get { return currentAmmo;}
    }
    public int ClipSize
    {
        get { return clipSize;}
    }
}
