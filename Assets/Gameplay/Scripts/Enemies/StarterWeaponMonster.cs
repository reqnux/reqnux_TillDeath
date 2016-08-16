using UnityEngine;
using System.Collections;

public class StarterWeaponMonster : MonoBehaviour {

	[SerializeField] Weapon weapon; 

	void OnDestroy() {
		Instantiate(weapon, transform.position, Quaternion.identity);
	}
}
