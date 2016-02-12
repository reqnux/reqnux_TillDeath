using UnityEngine;
using System.Collections;

[System.Serializable]
public class UnitStats {

    [SerializeField]  int damage;
    [SerializeField]  int movementSpeed;
    private int currentHealth;
    [SerializeField]  int maxHealth;
    [SerializeField]  int bonusChance;

    public int Damage{ get {return damage;} set{damage = value;}}
    public int MovementSpeed{ get {return movementSpeed;} set{movementSpeed = value;}}
    public int CurrentHealth{ get {return currentHealth;} set{currentHealth = value;}}
    public int MaxHealth{ get {return maxHealth;} set{maxHealth = value;}}
    public int BonusChance{ get {return bonusChance;} set{bonusChance = value;}}
}
