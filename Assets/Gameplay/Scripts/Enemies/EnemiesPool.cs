using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemiesPool : MonoBehaviour {

	public static EnemiesPool pool;

	[SerializeField] Zombie zombie;
	[SerializeField] FastZombie fastZombie;
	[SerializeField] StrongZombie strongZombie;
	[SerializeField] DoubleZombie doubleZombie;
	[SerializeField] Zombie zombiePartRight;
	[SerializeField] Zombie zombiePartLeft;

	[SerializeField] int zombiePoolSize = 30;
	[SerializeField] int fastPoolSize = 30;
	[SerializeField] int strongPoolSize = 30;
	[SerializeField] int doublePoolSize = 30;
	[SerializeField] int rightPoolSize = 30;
	[SerializeField] int leftPoolSize = 30;

	[SerializeField] List<Zombie> zombiePool;
	[SerializeField] List<FastZombie> fastPool;
	[SerializeField] List<StrongZombie> strongPool;
	[SerializeField] List<DoubleZombie> doublePool;
	[SerializeField] List<Zombie> rightPool;
	[SerializeField] List<Zombie> leftPool;

	void Awake() {
		pool = this;
	}
	void Start () {
		zombiePool = new List<Zombie> ();
		for (int i = 0; i < zombiePoolSize; i++) {
			addZombieToPool ();
		}
		fastPool = new List<FastZombie> ();
		for (int i = 0; i < fastPoolSize; i++) {
			addFastToPool ();
		}
		strongPool = new List<StrongZombie> ();
		for (int i = 0; i < strongPoolSize; i++) {
			addStrongToPool ();
		}
		doublePool = new List<DoubleZombie> ();
		for (int i = 0; i < doublePoolSize; i++) {
			addDoubleToPool ();
		}
		rightPool = new List<Zombie> ();
		for (int i = 0; i < rightPoolSize; i++) {
			addRightToPool ();
		}
		leftPool = new List<Zombie> ();
		for (int i = 0; i < leftPoolSize; i++) {
			addLeftToPool ();
		}
	}

	public Enemy getEnemy(EnemyType type) {
		switch (type) {
			case EnemyType.FAST_ZOMBIE: return getFastZombie ();
			case EnemyType.STRONG_ZOMBIE: return getStrongZombie ();
			case EnemyType.DOUBLE_ZOMBIE: return getDoubleZombie ();
			case EnemyType.ZOMBIE_PART_RIGHT: return getZombieRightPart ();
			case EnemyType.ZOMBIE_PART_LEFT: return getZombieLeftPart ();
			default : return getZombie ();
		}
	}
	public Enemy getRandomEnemy() {
		EnemyType random = (EnemyType)Random.Range (0, EnemyType.GetNames (typeof(EnemyType)).Length);
		while(random == EnemyType.ZOMBIE_PART_LEFT || random == EnemyType.ZOMBIE_PART_RIGHT)
			random = (EnemyType)Random.Range (0, EnemyType.GetNames (typeof(EnemyType)).Length);
		return getEnemy (random);
	}

	Zombie getZombie() {
		for (int i = 0; i < zombiePool.Count; i++) {
			if (!zombiePool [i].gameObject.activeInHierarchy)
				return zombiePool [i];
		}
		return addZombieToPool ();
	}
	FastZombie getFastZombie() {
		for (int i = 0; i < fastPool.Count; i++) {
			if (!fastPool [i].gameObject.activeInHierarchy)
				return fastPool [i];
		}
		return addFastToPool ();
	}
	StrongZombie getStrongZombie() {
		for (int i = 0; i < strongPool.Count; i++) {
			if (!strongPool [i].gameObject.activeInHierarchy)
				return strongPool [i];
		}
		return addStrongToPool ();
	}
	DoubleZombie getDoubleZombie() {
		for (int i = 0; i < doublePool.Count; i++) {
			if (!doublePool [i].gameObject.activeInHierarchy)
				return doublePool [i];
		}
		return addDoubleToPool ();
	}
	Zombie getZombieRightPart() {
		for (int i = 0; i < rightPool.Count; i++) {
			if (!rightPool [i].gameObject.activeInHierarchy)
				return rightPool [i];
		}
		return addRightToPool ();
	}
	Zombie getZombieLeftPart() {
		for (int i = 0; i < leftPool.Count; i++) {
			if (!leftPool [i].gameObject.activeInHierarchy)
				return leftPool [i];
		}
		return addLeftToPool ();
	}

	Zombie addZombieToPool() {
		Zombie obj = (Zombie)Instantiate (zombie);
		obj.gameObject.SetActive (false);
		zombiePool.Add (obj);
		obj.transform.SetParent (transform);
		return obj;
	}

	FastZombie addFastToPool() {
		FastZombie obj = (FastZombie)Instantiate (fastZombie);
		obj.gameObject.SetActive (false);
		fastPool.Add (obj);
		obj.transform.SetParent (transform);
		return obj;
	}
	StrongZombie addStrongToPool() {
		StrongZombie obj = (StrongZombie)Instantiate (strongZombie);
		obj.gameObject.SetActive (false);
		strongPool.Add (obj);
		obj.transform.SetParent (transform);
		return obj;
	}
	DoubleZombie addDoubleToPool() {
		DoubleZombie obj = (DoubleZombie)Instantiate (doubleZombie);
		obj.gameObject.SetActive (false);
		doublePool.Add (obj);
		obj.transform.SetParent (transform);
		return obj;
	}
	Zombie addRightToPool() {
		Zombie obj = (Zombie)Instantiate (zombiePartRight);
		obj.gameObject.SetActive (false);
		rightPool.Add (obj);
		obj.transform.SetParent (transform);
		return obj;
	}
	Zombie addLeftToPool() {
		Zombie obj = (Zombie)Instantiate (zombiePartLeft);
		obj.gameObject.SetActive (false);
		leftPool.Add (obj);
		obj.transform.SetParent (transform);
		return obj;
	}
}
