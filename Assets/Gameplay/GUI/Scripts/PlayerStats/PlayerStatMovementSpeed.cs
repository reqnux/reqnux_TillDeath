using UnityEngine;
using System.Collections;

public class PlayerStatMovementSpeed : PlayerStat {

	public override void addPoint () {
		pointsAddedWhilePanelOpen++;
		player.StatPoints--;
		player.Stats.StatPointsMovementSpeed += (int)statPerPoint;
	}
	public override void removePoint () {
		pointsAddedWhilePanelOpen--;
		player.StatPoints++;
		player.Stats.StatPointsMovementSpeed -= (int)statPerPoint;
	}

	protected override void setValue() {
		valueText.text = player.Stats.MovementSpeed.ToString();
		if (player.Stats.BonusMovementSpeed > 0)
			valueText.color = Color.green;
		else
			valueText.color = Color.red;
	}
}
