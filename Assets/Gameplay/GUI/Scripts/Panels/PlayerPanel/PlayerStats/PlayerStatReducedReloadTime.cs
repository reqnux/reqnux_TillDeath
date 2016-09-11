using UnityEngine;
using System.Collections;

public class PlayerStatReducedReloadTime : PlayerStat {

	public override void addPoint () {
		pointsAddedWhilePanelOpen++;
		player.StatPoints--;
		player.Stats.StatPointsReducedReloadTime += (int)statPerPoint;
	}
	public override void removePoint () {
		pointsAddedWhilePanelOpen--;
		player.StatPoints++;
		player.Stats.StatPointsReducedReloadTime -= (int)statPerPoint;
	}

	protected override void setValue() {
		valueText.text = player.Stats.ReducedReloadTime.ToString() + "%";
		if (player.Stats.BonusReducedReloadTime > 0)
			valueText.color = Color.green;
		else
			valueText.color = Color.red;
	}
}
