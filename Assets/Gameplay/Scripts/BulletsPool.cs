using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BulletsPool : MonoBehaviour {

	public static BulletsPool pool;

	[SerializeField] Bullet standardPrefab;
	[SerializeField] PiercingBullet piercingPrefab;
	[SerializeField] GranadeBullet granadePrefab;
	[SerializeField] Explosion explosionPrefab;
	[SerializeField] int standardPoolSize = 30;
	[SerializeField] int piercingPoolSize = 30;
	[SerializeField] int granadePoolSize = 20;
	[SerializeField] int explosionPoolSize = 20;
	[SerializeField] List<Bullet> standardPool;
	[SerializeField] List<PiercingBullet> piercingPool;
	[SerializeField] List<GranadeBullet> granadePool;
	[SerializeField] List<Explosion> explosionPool;

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
		granadePool = new List<GranadeBullet> ();
		for (int i = 0; i < granadePoolSize; i++) {
			addGranadeToPool ();
		}
	}

	public Bullet getBullet(BulletType type) {
		if (type == BulletType.STANDARD)
			return getStandardBullet ();
		else if (type == BulletType.PIERCING)
			return getPiercingBullet ();
		else 
			return getGranadeBullet ();
	}
	public Explosion getExplosion() {
		for (int i = 0; i < explosionPool.Count; i++) {
			if (!explosionPool [i].gameObject.activeInHierarchy)
				return explosionPool [i];
		}
		return addExplosionToPool ();
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
	GranadeBullet getGranadeBullet() {
		for (int i = 0; i < granadePool.Count; i++) {
			if (!granadePool [i].gameObject.activeInHierarchy)
				return granadePool [i];
		}
		return addGranadeToPool ();
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
	GranadeBullet addGranadeToPool() {
		GranadeBullet obj = (GranadeBullet)Instantiate (granadePrefab);
		obj.gameObject.SetActive (false);
		granadePool.Add (obj);
		obj.transform.SetParent (transform);
		return obj;
	}


	Explosion addExplosionToPool() {
		Explosion obj = (Explosion)Instantiate (explosionPrefab);
		obj.gameObject.SetActive (false);
		explosionPool.Add (obj);
		obj.transform.SetParent (transform);
		return obj;
	}
}
