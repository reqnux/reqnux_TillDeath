using UnityEngine;
using System.Collections;

public class PlayerStatIncreasedBonusDuration : PlayerStat {

	public override void addPoint () {
		pointsAddedWhilePanelOpen++;
		totalPointAdded++;
		player.StatPoints--;
		player.Stats.StatPointsIncreasedBonusDuration += statPerPoint/100f;
	}
	public override void removePoint () {
		pointsAddedWhilePanelOpen--;
		totalPointAdded--;
		player.StatPoints++;
		player.Stats.StatPointsIncreasedBonusDuration -= statPerPoint/100f;
	}

	protected override void setValue() {
		valueText.text = (Mathf.Round(player.Stats.IncreasedBonusDuration * 100f)).ToString() + "%";
	}
}
