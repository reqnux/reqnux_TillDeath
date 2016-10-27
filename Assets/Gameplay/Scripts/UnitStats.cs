using UnityEngine;
using System.Collections;

[System.Serializable]
public class UnitStats {

    [SerializeField] float damage;
	[SerializeField] float movementSpeed;
	private float currentHealth;
	[SerializeField] float maxHealth;
	[SerializeField] int experience;
	[SerializeField] int itemDropChance;

	float bonusDamage;
	float bonusMovementSpeed;
	float bonusMaxHealth;
	int bonusItemDropChance;

    //player's stats
	int bonusExperienceGained; // %
    float bonusReducedReloadTime; // %
    float bonusReducedTimeBetweenShots; // %
	int bonusIncreasedMagazineSize; // %

	float statPointsMaxHealth;
	float statPointsMovementSpeed;
	int statPointsItemDropChance;
	float statPointsReducedReloadTime;
	float statPointsIncreasedBonusDuration;


	public float Damage{ get {return damage + bonusDamage;}}
	public float MovementSpeed{ get {return movementSpeed + bonusMovementSpeed + statPointsMovementSpeed;}}
	public float CurrentHealth{ get {return currentHealth;} set{currentHealth = value;}}
	public float MaxHealth{ get {return maxHealth + bonusMaxHealth + statPointsMaxHealth;}}
	public int Experience{ get {return experience;} set{ experience = value;}}
	public int ItemDropChance{ get {return itemDropChance + bonusItemDropChance + statPointsItemDropChance;}}
	public float ReducedReloadTime{ get{return bonusReducedReloadTime + statPointsReducedReloadTime;}}
    public float ReducedTimeBetweenShots{ get{return bonusReducedTimeBetweenShots;}}
	public float IncreasedBonusDuration{get {return statPointsIncreasedBonusDuration;}}
	public float IncreasedMagazineSize{get {return bonusIncreasedMagazineSize;}}

	public float BaseDamage{ get {return damage;} set{damage = value;}}
    public float BaseMovementSpeed{ get {return movementSpeed;} set{movementSpeed = value;}}
	public float BaseMaxHealth{ get {return maxHealth;} set{maxHealth = value;}}
    public int BaseItemDropChance{ get {return itemDropChance;} set{itemDropChance = value;}}

	public float BonusDamage{ get {return bonusDamage;} set{bonusDamage = value;}}
    public float BonusMovementSpeed{ get {return bonusMovementSpeed;} set{bonusMovementSpeed = value;}}
	public float BonusMaxHealth{ get {return bonusMaxHealth;} set{bonusMaxHealth = value;}}
	public int BonusExperienceGained{ get {return bonusExperienceGained;} set{bonusExperienceGained = value;}}
    public int BonusItemDropChance{ get {return bonusItemDropChance;} set{bonusItemDropChance = value;}}
    public float BonusReducedReloadTime{ get{return bonusReducedReloadTime;} set{bonusReducedReloadTime = value;}}
    public float BonusReducedTimeBetweenShots{ get{return bonusReducedTimeBetweenShots;} set{bonusReducedTimeBetweenShots = value;}}
	public int BonusIncreasedMagazineSize{get {return bonusIncreasedMagazineSize;} set{ bonusIncreasedMagazineSize = value;}}

	public float StatPointsMaxHealth{ get {return statPointsMaxHealth;} set{statPointsMaxHealth = value;}}
	public float StatPointsMovementSpeed{ get {return statPointsMovementSpeed;} set{statPointsMovementSpeed = value;}}
	public int StatPointsItemDropChance{ get {return statPointsItemDropChance;} set{statPointsItemDropChance = value;}}
	public float StatPointsReducedReloadTime{ get {return statPointsReducedReloadTime;} set{statPointsReducedReloadTime = value;}}
	public float StatPointsIncreasedBonusDuration{ get {return statPointsIncreasedBonusDuration;} set{statPointsIncreasedBonusDuration = value;}}

}
