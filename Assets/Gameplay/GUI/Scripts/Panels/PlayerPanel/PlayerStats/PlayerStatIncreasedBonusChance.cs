using UnityEngine;
using System.Collections;

public class PlayerStatIncreasedBonusChance : PlayerStat {

	public override void addPoint () {
		pointsAddedWhilePanelOpen++;
		totalPointAdded++;
		player.StatPoints--;
		player.Stats.StatPointsItemDropChance += (int)statPerPoint;
	}
	public override void removePoint () {
		pointsAddedWhilePanelOpen--;
		totalPointAdded--;
		player.StatPoints++;
		player.Stats.StatPointsItemDropChance -= (int)statPerPoint;
	}

	protected override void setValue() {
		valueText.text = player.Stats.ItemDropChance.ToString() + "%";
	}
}
