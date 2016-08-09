using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ObjectPool : MonoBehaviour {

	[SerializeField] GameObject objectPrefab;
	[SerializeField] int poolSize = 30;
	[SerializeField] List<GameObject> pool;

	void Start () {
		pool = new List<GameObject> ();
		for (int i = 0; i < poolSize; i++) {
			addObjectToPool ();
		}
	}

	public GameObject getObjectFromPool() {
		for (int i = 0; i < pool.Count; i++) {
			if (!pool [i].activeInHierarchy)
				return pool [i];
		}
		return addObjectToPool ();
	}


	GameObject addObjectToPool() {
		GameObject obj = (GameObject)Instantiate (objectPrefab);
		obj.SetActive (false);
		pool.Add (obj);
		return obj;
	}
}
