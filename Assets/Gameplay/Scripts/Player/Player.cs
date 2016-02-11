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
        stats.CurrentHealth = stats.MaxHealth/2;
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
    }
    public Weapon CurrentWeapon
    {
        get{return currentWeapon;} 
    }

}
