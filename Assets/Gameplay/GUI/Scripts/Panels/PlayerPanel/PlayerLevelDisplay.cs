using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerLevelDisplay : MonoBehaviour {

	Player player;

	void Awake () {
		player = GameManager.Player;
	}
	
	void OnEnable () {
		transform.GetComponentInChildren<Text> ().text = player.Level.ToString ();
	}
}

