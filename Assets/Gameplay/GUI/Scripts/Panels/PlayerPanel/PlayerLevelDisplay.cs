using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerLevelDisplay : MonoBehaviour {

	Player player;

	void Awake () {
		player = GameObject.FindObjectOfType<Player> ();
	}
	
	void OnEnable () {
		transform.GetComponentInChildren<Text> ().text = player.Level.ToString ();
	}
}

