﻿using UnityEngine;
using System.Collections;

public class PlayerStatHealth : PlayerStat {

	public override void addPoint () {
		pointsAddedWhilePanelOpen++;
		totalPointAdded++;
		player.StatPoints--;
		player.Stats.StatPointsMaxHealth += statPerPoint;
		if (player.Stats.CurrentHealth > 0)
			player.Stats.CurrentHealth += statPerPoint;
		
	}
	public override void removePoint () {
		pointsAddedWhilePanelOpen--;
		totalPointAdded--;
		player.StatPoints++;
		player.Stats.StatPointsMaxHealth -= statPerPoint;
		player.Stats.CurrentHealth -= statPerPoint;
	}

	protected override void setValue() {
		valueText.text = Mathf.Round(player.Stats.MaxHealth).ToString();
	}
}
