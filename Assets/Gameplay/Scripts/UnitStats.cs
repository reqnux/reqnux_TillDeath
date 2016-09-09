using UnityEngine;
using System.Collections;

[System.Serializable]
public class UnitStats {

    [SerializeField]  int damage;
    [SerializeField]  int movementSpeed;
    private int currentHealth;
    [SerializeField]  int maxHealth;
	[SerializeField]  int increasedItemDropChance;

    int bonusDamage;
    int bonusMovementSpeed;
    int bonusMaxHealth;
	int bonusIncreasedItemDropChance;

    //player's stats
    float bonusReducedReloadTime; // %
    float bonusReducedTimeBetweenShots; // %

	int statPointsMaxHealth;
	int statPointsMovementSpeed;
	int statPointsIncreasedItemDropChance;
	float statPointsReducedReloadTime;
	float statPointsIncreasedBonusDuration;


    public int Damage{ get {return damage + bonusDamage;}}
	public int MovementSpeed{ get {return movementSpeed + bonusMovementSpeed + statPointsMovementSpeed;}}
    public int CurrentHealth{ get {return currentHealth;} set{currentHealth = value;}}
	public int MaxHealth{ get {return maxHealth + bonusMaxHealth + statPointsMaxHealth;}}
	public int IncreasedItemDropChance{ get {return increasedItemDropChance + bonusIncreasedItemDropChance + statPointsIncreasedItemDropChance;}}
	public float ReducedReloadTime{ get{return bonusReducedReloadTime + statPointsReducedReloadTime;}}
    public float ReducedTimeBetweenShots{ get{return bonusReducedTimeBetweenShots;}}
	public float IncreasedBonusDuration{get {return statPointsIncreasedBonusDuration;}}

    public int BaseDamage{ get {return damage;} set{damage = value;}}
    public int BaseMovementSpeed{ get {return movementSpeed;} set{movementSpeed = value;}}
    public int BaseMaxHealth{ get {return maxHealth;} set{maxHealth = value;}}
    public int BaseIncreasedItemDropChance{ get {return increasedItemDropChance;} set{increasedItemDropChance = value;}}

    public int BonusDamage{ get {return bonusDamage;} set{bonusDamage = value;}}
    public int BonusMovementSpeed{ get {return bonusMovementSpeed;} set{bonusMovementSpeed = value;}}
    public int BonusMaxHealth{ get {return bonusMaxHealth;} set{bonusMaxHealth = value;}}
    public int BonusIncreasedItemDropChance{ get {return bonusIncreasedItemDropChance;} set{bonusIncreasedItemDropChance = value;}}
    public float BonusReducedReloadTime{ get{return bonusReducedReloadTime;} set{bonusReducedReloadTime = value;}}
    public float BonusReducedTimeBetweenShots{ get{return bonusReducedTimeBetweenShots;} set{bonusReducedTimeBetweenShots = value;}}

	public int StatPointsMaxHealth{ get {return statPointsMaxHealth;} set{statPointsMaxHealth = value;}}
	public int StatPointsMovementSpeed{ get {return statPointsMovementSpeed;} set{statPointsMovementSpeed = value;}}
	public int StatPointsIncreasedItemDropChance{ get {return statPointsIncreasedItemDropChance;} set{statPointsIncreasedItemDropChance = value;}}
	public float StatPointsReducedReloadTime{ get {return statPointsReducedReloadTime;} set{statPointsReducedReloadTime = value;}}
	public float StatPointsIncreasedBonusDuration{ get {return statPointsIncreasedBonusDuration;} set{statPointsIncreasedBonusDuration = value;}}

}
