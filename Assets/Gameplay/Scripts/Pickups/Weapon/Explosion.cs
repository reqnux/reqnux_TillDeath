using UnityEngine;
using System.Collections;

public class Explosion : MonoBehaviour {

	[SerializeField] float explosionTime = 1;

	void OnEnable() {
		Invoke ("deactivate", explosionTime);	
	}
	void deactivate() {
		gameObject.SetActive (false);
	}
}
