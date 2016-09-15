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

	GameObject plusButton;
	GameObject minusButton;

	public abstract void addPoint ();
	public abstract void removePoint ();
	protected abstract void setValue ();

	void Awake() {
		player = GameManager.Player;
		valueText = transform.FindChild ("Value").GetChild(0).GetComponent<Text> ();
		plusButton = transform.FindChild ("AddPointButton").gameObject;
		minusButton = transform.FindChild ("RemovePointButton").gameObject;
	}
	void Update() {
		handleButtonsDisplay ();
		setValue ();
	}
	public bool showPlusButton() {
		return player.StatPoints > 0;
	}

	public bool showMinusButton() {
		return pointsAddedWhilePanelOpen > 0;
	}

	void handleButtonsDisplay() {
		if (showPlusButton ())
			plusButton.SetActive (true);
		else
			plusButton.SetActive (false);
		
		if (showMinusButton ())
			minusButton.SetActive (true);
		else
			minusButton.SetActive (false);
	}

	void OnDisable() {
		pointsAddedWhilePanelOpen = 0;
	}
}
