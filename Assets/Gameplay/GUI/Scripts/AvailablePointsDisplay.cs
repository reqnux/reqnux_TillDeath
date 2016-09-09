using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class AvailablePointsDisplay : MonoBehaviour {

	Player player;

	void Awake() {
		player = GameObject.FindObjectOfType<Player> ();
	}

	void Update () {
		transform.GetChild(0).GetComponent<Text>().text = player.StatPoints.ToString();
	}
}
