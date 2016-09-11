using UnityEngine;
using System.Collections;

public class PlayerStatHealth : PlayerStat {

	public override void addPoint () {
		pointsAddedWhilePanelOpen++;
		player.StatPoints--;
		player.Stats.StatPointsMaxHealth += (int)statPerPoint;
		if (player.Stats.CurrentHealth > 0)
			player.Stats.CurrentHealth += (int)statPerPoint;
		
	}
	public override void removePoint () {
		pointsAddedWhilePanelOpen--;
		player.StatPoints++;
		player.Stats.StatPointsMaxHealth -= (int)statPerPoint;
		player.Stats.CurrentHealth -= (int)statPerPoint;
	}

	protected override void setValue() {
		valueText.text = player.Stats.MaxHealth.ToString();
	}
}
