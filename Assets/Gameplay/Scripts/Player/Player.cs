using UnityEngine;
using System.Collections;

public class Player : Unit {

    // Use this for initialization
    public override void Start () 
    {
        base.Start();
        stats.MovementSpeed = 5;
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

    [SerializeField]
    private Weapon currentWeapon;
}
