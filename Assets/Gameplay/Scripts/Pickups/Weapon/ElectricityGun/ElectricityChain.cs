using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ElectricityChain : MonoBehaviour {

    [SerializeField] ElectricityChain effectPrefab;
    Weapon weapon;

    [SerializeField]float range = 2.0f;
    [SerializeField] int maxChainLength = 4; // max number of chain parts
    int chainPartsLeft;

    Transform source; 
    Transform target; 
    List<Enemy> enemiesHit;

    void Awake()
    {
        enemiesHit = new List<Enemy>();
        chainPartsLeft = maxChainLength;
    }

    public void initFromWeapon(Weapon weapon, Transform hitEnemy)
    {
        this.weapon = weapon;
        this.target = hitEnemy;
        GetComponent<ElectricityEffect>().initEffect(target);
        dealDamage(target.GetComponent<Enemy>());
        findNextTarget();
    }

    public void initFromChain(Weapon weapon, Transform source, Transform target, int chainPartsLeft, List<Enemy> enemiesHit)
    {
        if (chainPartsLeft > 0)
        {
            this.weapon = weapon;
            this.source = source;
            this.target = target;
            this.chainPartsLeft = chainPartsLeft;
            this.enemiesHit = enemiesHit;
            dealDamage(target.GetComponent<Enemy>());
            GetComponent<ElectricityEffect>().initEffect(source, target);
            findNextTarget();
        }
    }

    void findNextTarget () 
    {
        Enemy nextTarget = findTarget();
        if (nextTarget != null)
            setupNextEffect(nextTarget.transform);
    }

    Enemy findTarget() // HIGH MEMORY USAGE ?
    {
        Collider2D[] enemiesInRange = Physics2D.OverlapCircleAll(target.position, range);
        int i = 0;
        while (i < enemiesInRange.Length)
        {
            if (enemiesInRange[i] != null && enemiesInRange[i].tag == "Enemy" 
                && !enemiesHit.Contains(enemiesInRange[i].GetComponent<Enemy>()))
                return enemiesInRange[i].GetComponent<Enemy>();
            i++;
        }
        return null;
    }

    void setupNextEffect(Transform targetTransform)
    {
        ElectricityChain effect = (ElectricityChain)Instantiate(effectPrefab, target.position,target.rotation);
        effect.initFromChain(weapon, target, targetTransform, chainPartsLeft - 1, enemiesHit);

    }

    void dealDamage(Enemy e)
    {
        e.takeDamage(weapon.Player.Stats.Damage);
        enemiesHit.Add(e);
    }

	public float Range {
		get{ return range;}
	}

}
