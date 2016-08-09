using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BulletsPool : MonoBehaviour {

	public static BulletsPool pool;

	[SerializeField] Bullet standardPrefab;
	[SerializeField] PiercingBullet piercingPrefab;
	[SerializeField] int standardPoolSize = 30;
	[SerializeField] int piercingPoolSize = 30;
	[SerializeField] List<Bullet> standardPool;
	[SerializeField] List<PiercingBullet> piercingPool;

	void Awake() {
		pool = this;
	}
	void Start () {
		standardPool = new List<Bullet> ();
		for (int i = 0; i < standardPoolSize; i++) {
			addStandardToPool ();
		}
		piercingPool = new List<PiercingBullet> ();
		for (int i = 0; i < piercingPoolSize; i++) {
			addPiercingToPool ();
		}
	}

	public Bullet getBullet(BulletType type) {
		if (type == BulletType.STANDARD)
			return getStandardBullet ();
		else
			return getPiercingBullet ();
	}

	Bullet getStandardBullet() {
		for (int i = 0; i < standardPool.Count; i++) {
			if (!standardPool [i].gameObject.activeInHierarchy)
				return standardPool [i];
		}
		return addStandardToPool ();
	}
	PiercingBullet getPiercingBullet() {
		for (int i = 0; i < piercingPool.Count; i++) {
			if (!piercingPool [i].gameObject.activeInHierarchy)
				return piercingPool [i];
		}
		return addPiercingToPool ();
	}


	Bullet addStandardToPool() {
		Bullet obj = (Bullet)Instantiate (standardPrefab);
		obj.gameObject.SetActive (false);
		standardPool.Add (obj);
		obj.transform.SetParent (transform);
		return obj;
	}

	PiercingBullet addPiercingToPool() {
		PiercingBullet obj = (PiercingBullet)Instantiate (piercingPrefab);
		obj.gameObject.SetActive (false);
		piercingPool.Add (obj);
		obj.transform.SetParent (transform);
		return obj;
	}
}
