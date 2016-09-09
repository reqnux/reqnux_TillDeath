using UnityEngine;
using System.Collections;

public class PlayerStatIncreasedBonusDuration : PlayerStat {

	public override void addPoint () {
		pointsAddedWhilePanelOpen++;
		player.StatPoints--;
		player.Stats.StatPointsIncreasedBonusDuration += (int)statPerPoint;
	}
	public override void removePoint () {
		pointsAddedWhilePanelOpen--;
		player.StatPoints++;
		player.Stats.StatPointsIncreasedBonusDuration -= (int)statPerPoint;
	}

	protected override void setValue() {
		valueText.text = player.Stats.IncreasedBonusDuration.ToString();
	}
}
