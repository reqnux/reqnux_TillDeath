using UnityEngine;
using System.Collections;

public abstract class Weapon : PickableItem {

    protected Player player;

    [SerializeField] protected Rigidbody2D bulletPrefab;
    protected Transform gunEnding;
    protected WeaponSound weaponSound;

    [SerializeField] protected int damage;
    protected int currentAmmo;
    [SerializeField] protected int clipSize;
    protected bool flagReloading;

    [SerializeField] protected float reloadTime;
    [SerializeField] protected float delayBetweenShots;
    protected float lastShotTime;

    [SerializeField] protected int bulletSpeed;

    protected virtual void Awake () 
    {
        currentAmmo = clipSize;
        gunEnding = GameObject.Find("GunEnding").transform;
        weaponSound = transform.GetComponentInChildren<WeaponSound>();

    }
    protected override void Start()
    {
        base.Start();
    }

    protected abstract void spawnBullet();
    public virtual void shoot()
    {
        if (canShoot())
        {
            spawnBullet();
            weaponSound.playShotSound();
            lastShotTime = Time.time;
            currentAmmo--;
            if (currentAmmo == 0)
                reload();
        }
    }

    public void reload()
    {
        if(!flagReloading)
            StartCoroutine(reloadCoroutine());
    }
    IEnumerator reloadCoroutine()
    {
        flagReloading = true;
        float timeToReloadEnd = reloadTime * (1.0f - player.Stats.ReducedReloadTime);
        weaponSound.playReloadSound(timeToReloadEnd);
        yield return new WaitForSeconds(timeToReloadEnd);
        flagReloading = false;
        currentAmmo = clipSize;
    }

    protected bool canShoot()
    {
        return !flagReloading && currentAmmo > 0 
            && Time.time > lastShotTime + delayBetweenShots*(1.0f - player.Stats.ReducedTimeBetweenShots);
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

    public bool Reloading
    { 
        get{ return flagReloading;}
    }

    public Player Player
    {
        get{return player;}
        set{player = value;}
    }
}
