using UnityEngine;
using System.Collections;

public class Player : Unit {

    public delegate void PlayerDeathEvent();
    public static event PlayerDeathEvent playerDeathEvent;

    [SerializeField]  Weapon currentWeapon;

    private float timeBetweenDamage = 0.5f;
    private float lastDamageTakenTime;

    public override void Awake () 
    {
        base.Awake();
        stats.CurrentHealth = stats.MaxHealth;
    }

    void Start()
    {
        Weapon defaultWeapon = GameObject.Find("DefaultWeapon").GetComponent<Weapon>();
        if (defaultWeapon != null)
            useWeapon(defaultWeapon);
        else
            Debug.LogError("Player : No default weapon found on map!");
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
            stats.CurrentHealth -= damage;
            if (stats.CurrentHealth <= 0)
                death();
        }
    }

    public void useWeapon(Weapon weapon)
    {
        currentWeapon = weapon;
        weapon.Player = this;
        stats.Damage = weapon.Damage;
    }
    public Weapon CurrentWeapon
    {
        get{return currentWeapon;} 
    }

}
