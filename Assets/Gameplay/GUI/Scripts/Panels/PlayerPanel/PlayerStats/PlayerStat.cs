using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public abstract class PlayerStat : MonoBehaviour {

	[SerializeField] protected float statPerPoint;
	[SerializeField] int maxCap;

	protected int pointsAddedWhilePanelOpen;
	protected int totalPointAdded;

	protected Player player;
	protected Text valueText;

	Button plusButton;
	Button minusButton;

	public abstract void addPoint ();
	public abstract void removePoint ();
	protected abstract void setValue ();

	void Awake() {
		player = GameManager.Player;
		valueText = transform.FindChild ("Value").GetChild(0).GetComponent<Text> ();
		plusButton = transform.FindChild ("AddPointButton").GetComponent<Button>();
		minusButton = transform.FindChild ("RemovePointButton").GetComponent<Button>();
	}
	void Update() {
		handleButtonsDisplay ();
		setValue ();
	}
	public bool showPlusButton() {
		return player.StatPoints > 0 && totalPointAdded < maxCap;
	}

	public bool showMinusButton() {
		return pointsAddedWhilePanelOpen > 0;
	}

	void handleButtonsDisplay() {
		if (showPlusButton ())
			plusButton.interactable = true;
		else
			plusButton.interactable = false;
		
		if (showMinusButton ())
			minusButton.interactable = true;
		else
			minusButton.interactable = false;
	}

	void OnDisable() {
		pointsAddedWhilePanelOpen = 0;
	}
}
