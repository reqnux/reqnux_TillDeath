﻿using UnityEngine;
using System.Collections;

public abstract class Weapon : PickableItem {

	public virtual void Start () {
        currentBullets = clipSize;
	}
	
	void Update () {
	
	}

    public override void pickup()
    {
        
    }

    public void shoot()
    {
        
    }

    public void reload()
    {
        
    }


    [SerializeField] protected int damage;
    protected int currentBullets;
    [SerializeField] protected int clipSize;
    [SerializeField] protected float reloadTime;
    [SerializeField] protected float delayBetweenShots;
}
