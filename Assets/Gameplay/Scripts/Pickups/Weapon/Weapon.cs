using UnityEngine;
using System.Collections;

public enum FireMode
{
	SINGLE,
	MULTIPLE_FIXED, // multiple bullets shot in cone, every bullet shot with fixed angle
	MULTIPLE_RANDOM // multiple bullets shot in cone, every bullet shot with random angle
}

public abstract class Weapon : PickableItem {

    protected Player player;

    protected Transform gunEnding;
    protected WeaponSound weaponSound;

    [SerializeField] protected int damage;
    protected int currentAmmo;
    [SerializeField] protected int clipSize;
	[SerializeField] protected BulletType bulletType;
	[SerializeField] protected FireMode fireMode;

	protected int bulletsPerShot;
	protected int shotConeWidth; // degrees
	protected bool flagReloading;
    [SerializeField] protected float reloadTime;
    [SerializeField] protected float delayBetweenShots;
    protected float lastShotTime;
    protected float timeToReloadEnd;

    [SerializeField] protected int bulletSpeed;

    protected virtual void Awake () 
    {
        currentAmmo = clipSize;
        gunEnding = GameObject.Find("GunEnding").transform;
        weaponSound = transform.GetComponentInChildren<WeaponSound>();
		bulletsPerShot = 1;
		shotConeWidth = 30;
    }

    protected override void Start()
    {
        base.Start();
    }

	protected void spawnBullet()
	{
		Bullet bullet = BulletsPool.pool.getBullet(bulletType);
		bullet.transform.position = gunEnding.transform.position;
		bullet.transform.rotation = gunEnding.transform.rotation;
		bullet.gameObject.SetActive (true);
		bullet.GetComponent<Rigidbody2D>().velocity = gunEnding.transform.up * bulletSpeed;
		bullet.GetComponent<Bullet>().Weapon = this;
	}
	void spawnMultipleBullets(int randomAngle)
	{
		gunEnding.Rotate(new Vector3(0, 0, -shotConeWidth / 2));
		for (int i = 0; i < bulletsPerShot; i++)
		{
			spawnBullet();
			gunEnding.RotateAround(gunEnding.position, Vector3.forward, shotConeWidth / bulletsPerShot + Random.Range(-randomAngle, randomAngle));
		}
		gunEnding.localRotation = Quaternion.identity;
	}
    public virtual void shoot()
    {
        if (canShoot())
        {
			if (fireMode == FireMode.SINGLE)
				spawnBullet();
			else if (fireMode == FireMode.MULTIPLE_FIXED)
				spawnMultipleBullets (0);
			else if (fireMode == FireMode.MULTIPLE_RANDOM)
				spawnMultipleBullets (3);
			
			weaponSound.playShotSound();
			lastShotTime = Time.time;
			currentAmmo--;
			if (currentAmmo == 0)
				reload();
        }
    }

    public virtual void reload()
    {
        if(!flagReloading)
            StartCoroutine(reloadCoroutine());
    }
    IEnumerator reloadCoroutine()
    {
        flagReloading = true;
        timeToReloadEnd = reloadTime * (1.0f - player.Stats.ReducedReloadTime);
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

    public int CurrentAmmo {
		get { return currentAmmo; }
	}

	public int ClipSize {
		get { return clipSize; }
	}

	public int Damage { 
		get{ return damage; }
	}

	public bool Reloading { 
		get{ return flagReloading; }
	}

	public Player Player {
		get{ return player; }
		set{ player = value; }
	}

	public float ReloadTime {
		get{ return reloadTime; }
	}

	public float TimeToReloadEnd {
		get{ return timeToReloadEnd; }
	}

	public Transform GunEnding {
		get{ return gunEnding; }
	}

	public BulletType BulletType {
		get{ return bulletType; }
		set{ bulletType = value; }
	}

	public FireMode FireMode {
		get{ return fireMode; }
		set{ fireMode = value; }
	}
	public int BulletsPerShot {
		get{ return bulletsPerShot; }
		set{ bulletsPerShot = value; }
	}
}

