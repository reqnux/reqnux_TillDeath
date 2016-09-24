﻿using UnityEngine;
using System.Collections;

[System.Serializable]
public class UnitStats {

    [SerializeField] int damage;
	[SerializeField] float movementSpeed;
    private int currentHealth;
    [SerializeField] int maxHealth;
	[SerializeField] int experience;
	[SerializeField] int itemDropChance;

    int bonusDamage;
	float bonusMovementSpeed;
    int bonusMaxHealth;
	int bonusItemDropChance;

    //player's stats
	int bonusExperienceGained; // %
    float bonusReducedReloadTime; // %
    float bonusReducedTimeBetweenShots; // %
	int bonusIncreasedMagazineSize; // %

	int statPointsMaxHealth;
	float statPointsMovementSpeed;
	int statPointsItemDropChance;
	float statPointsReducedReloadTime;
	float statPointsIncreasedBonusDuration;


    public int Damage{ get {return damage + bonusDamage;}}
	public float MovementSpeed{ get {return movementSpeed + bonusMovementSpeed + statPointsMovementSpeed;}}
    public int CurrentHealth{ get {return currentHealth;} set{currentHealth = value;}}
	public int MaxHealth{ get {return maxHealth + bonusMaxHealth + statPointsMaxHealth;}}
	public int Experience{ get {return experience;} set{ experience = value;}}
	public int ItemDropChance{ get {return itemDropChance + bonusItemDropChance + statPointsItemDropChance;}}
	public float ReducedReloadTime{ get{return bonusReducedReloadTime + statPointsReducedReloadTime;}}
    public float ReducedTimeBetweenShots{ get{return bonusReducedTimeBetweenShots;}}
	public float IncreasedBonusDuration{get {return statPointsIncreasedBonusDuration;}}
	public float IncreasedMagazineSize{get {return bonusIncreasedMagazineSize;}}

    public int BaseDamage{ get {return damage;} set{damage = value;}}
    public float BaseMovementSpeed{ get {return movementSpeed;} set{movementSpeed = value;}}
    public int BaseMaxHealth{ get {return maxHealth;} set{maxHealth = value;}}
    public int BaseItemDropChance{ get {return itemDropChance;} set{itemDropChance = value;}}

    public int BonusDamage{ get {return bonusDamage;} set{bonusDamage = value;}}
    public float BonusMovementSpeed{ get {return bonusMovementSpeed;} set{bonusMovementSpeed = value;}}
    public int BonusMaxHealth{ get {return bonusMaxHealth;} set{bonusMaxHealth = value;}}
	public int BonusExperienceGained{ get {return bonusExperienceGained;} set{bonusExperienceGained = value;}}
    public int BonusItemDropChance{ get {return bonusItemDropChance;} set{bonusItemDropChance = value;}}
    public float BonusReducedReloadTime{ get{return bonusReducedReloadTime;} set{bonusReducedReloadTime = value;}}
    public float BonusReducedTimeBetweenShots{ get{return bonusReducedTimeBetweenShots;} set{bonusReducedTimeBetweenShots = value;}}
	public int BonusIncreasedMagazineSize{get {return bonusIncreasedMagazineSize;} set{ bonusIncreasedMagazineSize = value;}}

	public int StatPointsMaxHealth{ get {return statPointsMaxHealth;} set{statPointsMaxHealth = value;}}
	public float StatPointsMovementSpeed{ get {return statPointsMovementSpeed;} set{statPointsMovementSpeed = value;}}
	public int StatPointsItemDropChance{ get {return statPointsItemDropChance;} set{statPointsItemDropChance = value;}}
	public float StatPointsReducedReloadTime{ get {return statPointsReducedReloadTime;} set{statPointsReducedReloadTime = value;}}
	public float StatPointsIncreasedBonusDuration{ get {return statPointsIncreasedBonusDuration;} set{statPointsIncreasedBonusDuration = value;}}

}
