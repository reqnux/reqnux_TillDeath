using UnityEngine;
using System.Collections;

public class PlayerStatReducedReloadTime : PlayerStat {

	public override void addPoint () {
		pointsAddedWhilePanelOpen++;
		totalPointAdded++;
		player.StatPoints--;
		player.Stats.StatPointsReducedReloadTime += statPerPoint/100f;
	}
	public override void removePoint () {
		pointsAddedWhilePanelOpen--;
		totalPointAdded--;
		player.StatPoints++;
		player.Stats.StatPointsReducedReloadTime -= statPerPoint/100f;
	}

	protected override void setValue() {
		valueText.text = (Mathf.Round(player.Stats.ReducedReloadTime * 100f)).ToString() + "%";
		if (player.Stats.BonusReducedReloadTime > 0)
			valueText.color = Color.green;
		else
			valueText.color = Color.red;
	}
}
