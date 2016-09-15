using UnityEngine;
using System.Collections;

public class PlayerStatIncreasedBonusDuration : PlayerStat {

	public override void addPoint () {
		pointsAddedWhilePanelOpen++;
		totalPointAdded++;
		player.StatPoints--;
		player.Stats.StatPointsIncreasedBonusDuration += statPerPoint/100;
	}
	public override void removePoint () {
		pointsAddedWhilePanelOpen--;
		totalPointAdded--;
		player.StatPoints++;
		player.Stats.StatPointsIncreasedBonusDuration -= statPerPoint/100;
	}

	protected override void setValue() {
		valueText.text = (player.Stats.IncreasedBonusDuration * 100).ToString() + "%";
	}
}
