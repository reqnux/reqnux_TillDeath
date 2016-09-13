using UnityEngine;
using System.Collections;

public class Player : Unit {

    public delegate void PlayerDeathEvent();
    public static event PlayerDeathEvent playerDeathEvent;
	public static int ExperiencePerLevel = 500;

    [SerializeField]  Weapon currentWeapon;
	ActiveSpecialAbilities activeAbilities;
	int statPoints = 5;
	int level = 1;

    float timeBetweenDamage = 0.5f;
    float lastDamageTakenTime;
	AudioSource audioSource;

    public override void Awake () 
    {
        base.Awake();
        stats.CurrentHealth = stats.MaxHealth;
		activeAbilities = GetComponent<ActiveSpecialAbilities> ();
		audioSource = GetComponent<AudioSource> ();
		Enemy.enemyDeathEvent += getExperienceFromEnemy;

		if (currentWeapon != null)
			useWeapon(currentWeapon);
		else
			Debug.LogError("Player : No default weapon assigned!");
    }

    public override void death() 
    {
        if(playerDeathEvent != null)
            playerDeathEvent();
    }

    public override void takeDamage(int damage)
    {
        if (Time.time > lastDamageTakenTime + timeBetweenDamage)
        {
            lastDamageTakenTime = Time.time;
			if(activeAbilities.onDamageTaken != null)
				activeAbilities.onDamageTaken();
            stats.CurrentHealth -= damage;
            if (stats.CurrentHealth <= 0)
                death();
        }
    }

    public void useWeapon(Weapon weapon)
    {
        currentWeapon = weapon;
        weapon.Player = this;
		weapon.CurrentAmmo = weapon.MagazineSize;
        stats.BaseDamage = weapon.Damage;
        // recalculate bonusDamage, based on active bonuses
    }
	void getExperienceFromEnemy(Enemy enemy) {
		addExperience (enemy.Stats.Experience);
	}
	void addExperience(int exp) {
		int expGained = exp + exp * stats.BonusExperienceGained / 100;
		stats.Experience += expGained;
		if (stats.Experience / ExperiencePerLevel >= level)
			levelUp ();
	}

	void levelUp() {
		level++;
		audioSource.PlayOneShot (audioSource.clip);
	}

    public Weapon CurrentWeapon
    {
        get{return currentWeapon;} 
    }

	public int Level {
		get{ return level;}
	}

	public int StatPoints {
		get{ return statPoints;}
		set{ statPoints = value;}
	}
	public ActiveSpecialAbilities ActiveAbilities {
		get{ return activeAbilities;}
	}

}
