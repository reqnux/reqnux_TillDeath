using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LevelUpIndicator : MonoBehaviour {

	[SerializeField] Player player;
	Image imageComponent;
	Button buttonComponent;
	Text textComponent;

	void Awake () {
		Player.playerLevelUpEvent += onLevelUp;
		imageComponent = GetComponent<Image> ();
		buttonComponent = GetComponent<Button> ();
		textComponent = GetComponentInChildren<Text> ();
	}
	
	public void setVisible(bool value) {
		imageComponent.enabled = value;
		buttonComponent.enabled = value;
		textComponent.enabled = value;
	}

	void onLevelUp() {
		setVisible(true);
	}
}

