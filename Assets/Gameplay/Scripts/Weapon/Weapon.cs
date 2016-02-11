using UnityEngine;
using System.Collections;

public abstract class Weapon : MonoBehaviour {

    protected Player player;

    [SerializeField] protected Rigidbody2D bulletPrefab;
    protected Transform gunEnding;

    [SerializeField] protected int damage;
    protected int currentAmmo;
    [SerializeField] protected int clipSize;
    protected bool flagReloading;

    [SerializeField] protected float reloadTime;
    [SerializeField] protected float delayBetweenShots;
    protected float lastShotTime;

    [SerializeField] protected int bulletSpeed;

    public virtual void Awake () 
    {
        currentAmmo = clipSize;
        gunEnding = GameObject.Find("GunEnding").transform;
    }

    public abstract void shoot();
    protected abstract void spawnBullet();

    public void reload()
    {
        StartCoroutine(reloadCoroutine());
    }
    private IEnumerator reloadCoroutine()
    {
        flagReloading = true;
        yield return new WaitForSeconds(reloadTime);
        flagReloading = false;
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
    public int Damage
    { 
        get{ return damage;}
    }

    public Player Player
    {
        get{return player;}
        set{player = value;}
    }
}
