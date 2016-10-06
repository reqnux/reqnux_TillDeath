using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BloodPool : MonoBehaviour {

	public static BloodPool pool;

	[SerializeField] BloodSplashEffect splashPrefab;
	[SerializeField] int splashPoolSize = 30;
	[SerializeField] List<BloodSplashEffect> splashPool;

	void Awake() {
		pool = this;
	}

	void Start () {
		splashPool = new List<BloodSplashEffect> ();
		for (int i = 0; i < splashPoolSize; i++) {
			addSplashToPool ();
		}
	}

	public BloodSplashEffect getBloodSplashEffect() {
		for (int i = 0; i < splashPool.Count; i++) {
			if (!splashPool [i].gameObject.activeInHierarchy)
				return splashPool [i];
		}
		return addSplashToPool ();
	}

	BloodSplashEffect addSplashToPool() {
		BloodSplashEffect obj = (BloodSplashEffect)Instantiate (splashPrefab);
		obj.gameObject.SetActive (false);
		splashPool.Add (obj);
		obj.transform.SetParent (transform);
		return obj;
	}
}