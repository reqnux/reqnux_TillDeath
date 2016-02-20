using UnityEngine;
using System.Collections;

[System.Serializable]
public class UnitStats {

    [SerializeField]  int damage;
    [SerializeField]  int movementSpeed;
    private int currentHealth;
    [SerializeField]  int maxHealth;
    [SerializeField]  int itemDropChance;

    int bonusDamage;
    int bonusMovementSpeed;
    int bonusMaxHealth;
    int bonusItemDropChance;

    //player's stats
    float bonusReducedReloadTime; // %
    float bonusReducedTimeBetweenShots; // %


    public int Damage{ get {return damage + bonusDamage;}}
    public int MovementSpeed{ get {return movementSpeed + bonusMovementSpeed;}}
    public int CurrentHealth{ get {return currentHealth;} set{currentHealth = value;}}
    public int MaxHealth{ get {return maxHealth + bonusMaxHealth;}}
    public int ItemDropChance{ get {return itemDropChance + bonusItemDropChance;}}
    public float ReducedReloadTime{ get{return bonusReducedReloadTime;}}
    public float ReducedTimeBetweenShots{ get{return bonusReducedTimeBetweenShots;}}

    public int BaseDamage{ get {return damage;} set{damage = value;}}
    public int BaseMovementSpeed{ get {return movementSpeed;} set{movementSpeed = value;}}
    public int BaseMaxHealth{ get {return maxHealth;} set{maxHealth = value;}}
    public int BaseItemDropChance{ get {return itemDropChance;} set{itemDropChance = value;}}

    public int BonusDamage{ get {return bonusDamage;} set{bonusDamage = value;}}
    public int BonusMovementSpeed{ get {return bonusMovementSpeed;} set{bonusMovementSpeed = value;}}
    public int BonusMaxHealth{ get {return bonusMaxHealth;} set{bonusMaxHealth = value;}}
    public int BonusItemDropChance{ get {return bonusItemDropChance;} set{bonusItemDropChance = value;}}
    public float BonusReducedReloadTime{ get{return bonusReducedReloadTime;} set{bonusReducedReloadTime = value;}}
    public float BonusReducedTimeBetweenShots{ get{return bonusReducedTimeBetweenShots;} set{bonusReducedTimeBetweenShots = value;}}
}
