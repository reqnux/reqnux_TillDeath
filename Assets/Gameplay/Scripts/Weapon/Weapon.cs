using UnityEngine;
using System.Collections;

public abstract class Weapon : MonoBehaviour {

    [SerializeField] protected int damage;
    protected int currentBullets;
    [SerializeField] protected int clipSize;
    [SerializeField] protected float reloadTime;
    [SerializeField] protected float delayBetweenShots;

    public virtual void Start () 
    {
        currentBullets = clipSize;
    }
    
    void Update () {
    
    }

    public abstract void shoot();

    public void reload()
    {
        currentBullets = clipSize;
    }


}
