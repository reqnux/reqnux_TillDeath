using UnityEngine;
using System.Collections;

public class Player : Unit {

    [SerializeField]
    private Weapon currentWeapon;

    public override void Awake () 
    {
        base.Awake();
        stats.MovementSpeed = 5;
        stats.MaxHealth = 50;
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

    }

    public override void takeDamage(int damage)
    {

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
