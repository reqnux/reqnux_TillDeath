﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LevelUpIndicator : MonoBehaviour {

	[SerializeField] PlayerPanel playerPanel;

	Player player;
	Image imageComponent;
	Button buttonComponent;
	Text textComponent;

	void Awake () {
		Player.playerLevelUpEvent += onLevelUp;
		player = GameManager.Player;
		imageComponent = GetComponent<Image> ();
		buttonComponent = GetComponent<Button> ();
		textComponent = GetComponentInChildren<Text> ();
	}

	public void onClick() {
		if (!GameManager.gamePaused) {
			playerPanel.gameObject.SetActive (true);
		}
	}

	public void setVisible(bool value) {
		imageComponent.enabled = value;
		buttonComponent.enabled = value;
		textComponent.enabled = value;
	}

	void onLevelUp() {
		setVisible(true);
	}

	void OnDestroy() {
		Player.playerLevelUpEvent -= onLevelUp;
	}

}

